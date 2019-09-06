using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text;
using System.IO.Compression;
using System.Collections.Generic;
using ReaLearn_Core.Services.Abstract;
using ReaLearn_Core.Models;
using Microsoft.AspNetCore.Authorization;
using ReaLearn_Core.Models.VRObjectModels;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ReaLearn_Core.Controllers
{
    public class ExportController : Controller
    {
        private readonly ISceneService _sceneService;
        private readonly ICourseService _courseService;
        private readonly IVRObjectService _VRObjectService;
        private readonly IVRBackgroundService _VRBackgroundService;

        public ExportController(ISceneService sceneService, ICourseService courseService, IVRObjectService VRObjectService, IVRBackgroundService VRBackgroundService)
        {
            _sceneService = sceneService;
            _courseService = courseService;
            _VRObjectService = VRObjectService;
            _VRBackgroundService = VRBackgroundService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Export(int courseId)
        {
            // Get the course to be exported
            Course course = _courseService.GetCourse(courseId);

            // Create export directory under the courses ID
            CreateExportDirectory(course.Id);

            // Get all scenes under the course
            IEnumerable<Scene> scenes = _sceneService.GetScenesWithCourseId(courseId);

            // Set the scene index to 0
            int sceneIndex = 0;

            // cycle through each scene
            foreach (Scene item in scenes)
            {
                // Get all the vr Objects in the scene
                IEnumerable<VRObject> vRObjects = _VRObjectService.GetVROBjectsWithSceneId(item.Id);

                // for each vr object, if it's video or audio, find the file in the MEDIA folder and move it to the scorm content folder
                foreach(VRObject v in vRObjects)
                {
                    if (v.ObjectType == "VideoObject" || v.ObjectType == "AudioObject")
                    {
                        MoveMediaFileToScormContentFolder(v.ObjectType, v.Value, courseId);
                    }
                }

                // Getting all the hotspot, question and responses in the scene
                IEnumerable<VRHotspot> vRHotspots = _VRObjectService.GetVRHotspotsWithSceneId(item.Id);
                IEnumerable<VRQuestionCard> vRQuestionCards = _VRObjectService.GetVRQuestionsWithSceneId(item.Id);
                IEnumerable<VRQuestionResponse> tempResponses = new List<VRQuestionResponse>();
                List<VRQuestionResponse> responses = new List<VRQuestionResponse>();

                if (vRQuestionCards != null && vRQuestionCards.Count() > 0)
                {
                    foreach(VRQuestionCard q in vRQuestionCards)
                    {
                        // stores the individual question's responses in temp responses
                        // This is reset each iteration of the foreach loop
                        tempResponses = _VRObjectService.GetVRQuestionresponsesWithQuestionId(q.Id);
                        foreach (VRQuestionResponse r in tempResponses)
                        {
                            // iterate through the tempResponses to add the response to the responses to be exported
                            responses.Add(r);
                        }
                    }
                }
                // Get the current scenes background image
                VRBackground Image = _VRBackgroundService.getBackgroundImageObjectWithSceneId(item.Id);

                // Export Model to be passed to export.cshtml
                ExportModel eModel = new ExportModel()
                {
                    backgroundImage = Image,
                    VRObjects = vRObjects,
                    VRHotSpots = vRHotspots,
                    VRQuestionCards = vRQuestionCards,
                    VRQuestionResponses = responses
                };

                // Returns a string of the Export.cshtml after it has been populated with the above data
                string exportView = await this.RenderViewToStringAsync("/Views/Export/Export.cshtml", eModel);

                // Writes the above data to a html file for each scene
                WriteToFile(exportView, item.CourseId, sceneIndex);
                sceneIndex++;
            }

            // once the loop is complete, zip it as per the xAPI standard wrapper docs 
            ZipScorm(course.Id);

            // Relocate from the ZIPS to be downloaded by the user
            FileStreamResult fileStreamResult = null;
            try
            {
                string path = "C:/OPT/ZIPS/" + courseId + ".zip";
                FileStream fileStreamInput = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Delete);
                fileStreamResult = new FileStreamResult(fileStreamInput, "APPLICATION/octet-stream");
                fileStreamResult.FileDownloadName = "yourScorm.zip";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Ensure the zip is always deleted so the course can be downlaoded multiple times
                DeleteExportedZip(course.Id);
            }

            return fileStreamResult;
        }

        private void MoveMediaFileToScormContentFolder(string objectType, string value, int courseId)
        {
            // Moves videos and audio from media file on c:/ to scormContent folder
            string DIRECTORYEND = null;

            if (objectType == "VideoObject")
            {
                DIRECTORYEND = "VIDEO";
            }
            else if (objectType == "AudioObject")
            {
                DIRECTORYEND = "AUDIO";
            }

            // Checks if the directory exists
            DirectoryInfo DIR = new DirectoryInfo("C:/MEDIA/" + DIRECTORYEND);
            if (DIR.Exists)
            {   
                string filePath = @"" + DIR.ToString() + "/" + value;

                // checks if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // gets the source and target path and copies content from media folder to scormcontent for export
                    string sourcePath = @"C:/MEDIA/" + DIRECTORYEND + "/";
                    string targetPath = @"C:/OPT/EXPORTS/" + courseId + "/ScormPackage/scormcontent/";

                    string sourceFile = System.IO.Path.Combine(sourcePath, value);
                    string destFile = System.IO.Path.Combine(targetPath, value);

                    System.IO.Directory.CreateDirectory(targetPath);
                    System.IO.File.Copy(sourceFile, destFile, true);

                }
            }
        }


        private void DeleteExportedZip(int coursePK)
        {
            string ExportDirName = "C:/OPT/EXPORTS/" + coursePK;
            if (Directory.Exists(ExportDirName))
            {
                Directory.Delete(ExportDirName, true);
            }

            if (System.IO.File.Exists(@"C:/OPT/ZIPS/" + coursePK + ".zip"))
            {
                try
                {
                    // Delete the zip file
                    System.IO.File.Delete(@"C:/OPT/ZIPS/" + coursePK + ".zip");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        // Creates the export directory
        public void CreateExportDirectory(int coursePK)
        {
            string sourceDirName = "C:/OPT/DEFAULT";
            string destDirName = "C:/OPT/EXPORTS/" + coursePK;
            DirectoryInfo dir = new DirectoryInfo(destDirName);

            if (dir.Exists)
            {
                Directory.Delete(destDirName);
            }
                bool copySubDirs = true;
            DirectoryCopy(sourceDirName, destDirName, copySubDirs);
            /*
             * The following creates the appropriate configuration files for xAPI 
             * to work with the associated learning management system
             */

            Course course = _courseService.GetCourse(coursePK);
            string courseID = "https://" + coursePK + ".com/ReaLearn/Export";
            string courseTitle = course.Name;
            string courseDescript = course.Description;
            string endPoint = "https://cloud.scorm.com/lrs/2PMZCO8UFI/sandbox/";
            string key = "o3p8acLwfBkGb6XDPi8";
            string secret = "tyd1A_2pDXp6HrWb0QE";
            string auth = key + " " + secret;

            string congiJS = "" +
                "TC_COURSE_ID = '" + courseID + "'; \n" +
                "TC_COURSE_NAME = {\n" +
                "'en-US': '" + courseTitle + "' \n" +
                "};\n" +
                "TC_COURSE_DESC = {\n" +
                "'en-US': '" + courseDescript + "' \n" +
                "};\n" +
                "" +
                "TC_RECORD_STORES = [\n" +
                "/*{\n" +
                "endpoint: '" + endPoint + "',\n" +
                "auth:  '" + auth + "',\n" +
                "version: '0.95'\n" +
                "}*/\n" +
                "];";

            using (FileStream fs = new FileStream("C:/OPT/EXPORTS/" + coursePK + "/ScormPackage/tc-config.js", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(congiJS);
                }
            }

            string tincan = "" +
                "<?xml version='1.0' encoding='utf-8' ?>\n" +
                "<tincan xmlns='http://projecttincan.com/tincan.xsd'>\n" +
                "\t<activities>\n" +
                "\t\t<activity id='" + courseID + "' type='http://adlnet.gov/expapi/activities/course'>\n" +
                "\t\t\t<name>" + courseTitle + "</name>\n" +
                "\t\t\t<description lang='en-US'>" + courseDescript + "</description>\n" +
                "\t\t\t<launch lang='en-us'>scormdriver/indexAPI.html</launch>\n" +
                "\t\t</activity>\n" +
                "\t</activities>\n" +
                "</tincan>";

            using (FileStream fs = new FileStream("C:/OPT/EXPORTS/" + coursePK + "/ScormPackage/tincan.xml", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(tincan);
                }
            }
        }
        public void WriteToFile(string html, int coursePK, int sceneIndex)
        {
            using (FileStream fs = new FileStream("C:/OPT/EXPORTS/" + coursePK + "/ScormPackage/scormcontent/Page" + sceneIndex + ".html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(html);
                }
            }

        }

        public void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }


        }

        public void ZipScorm(int courseId)
        {
            string startPath = "C:/OPT/EXPORTS/" + courseId;

            string zipPath = "C:/OPT/ZIPS/" + courseId + ".zip";

            ZipFile.CreateFromDirectory(startPath, zipPath);

        }
    } 

    public static class ControllerExtensions
    {
        /// <summary>
        /// Render a partial view to string.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="controller"></param>
        /// <param name="viewNamePath"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<string> RenderViewToStringAsync<TModel>(this Controller controller, string viewNamePath, TModel model)
        {
            if (string.IsNullOrEmpty(viewNamePath))
                viewNamePath = controller.ControllerContext.ActionDescriptor.ActionName;

            controller.ViewData.Model = model;

            using (StringWriter writer = new StringWriter())
            {
                try
                {
                    IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

                    ViewEngineResult viewResult = null;

                    if (viewNamePath.EndsWith(".cshtml"))
                        viewResult = viewEngine.GetView(viewNamePath, viewNamePath, false);
                    else
                        viewResult = viewEngine.FindView(controller.ControllerContext, viewNamePath, false);

                    if (!viewResult.Success)
                        return $"A view with the name '{viewNamePath}' could not be found";

                    ViewContext viewContext = new ViewContext(
                        controller.ControllerContext,
                        viewResult.View,
                        controller.ViewData,
                        controller.TempData,
                        writer,
                        new HtmlHelperOptions()
                    );

                    await viewResult.View.RenderAsync(viewContext);

                    return writer.GetStringBuilder().ToString();
                }
                catch (Exception exc)
                {
                    return $"Failed - {exc.Message}";
                }
            }
        }
    }

}