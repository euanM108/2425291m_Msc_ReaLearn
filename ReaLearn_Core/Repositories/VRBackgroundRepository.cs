using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Data;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class VRBackgroundRepository : Repository<VRBackground>, IVRBackgroundRepository
    {
        private ApplicationDbContext _context { get; set; }
        public VRBackgroundRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }


        public byte[] getBackgroundImageBytesWithSceneId(int id)
        {
            return _context.Set<VRBackground>().Where(c => c.SceneId == id).FirstOrDefault().Img;
        }

        public void UpdateColour(string colour, int sceneId)
        {
            var result = _context.Set<VRBackground>().Where(c => c.SceneId == sceneId).FirstOrDefault();
            result.Colour = colour;
            _context.SaveChanges();
        }

        public VRBackground getBackgroundWithSceneId(int sceneId)
        {
            return _context.Set<VRBackground>().Where(c => c.SceneId == sceneId).FirstOrDefault();
        }

       
        public void AddBackground(VRBackground background)
        {
            _context.Set<VRBackground>().Add(background);
            _context.SaveChanges();
        }
       
        public void UpdateBackground(VRBackground background)
        {
            var currentBackground = _context.Set<VRBackground>().Where(c => c.SceneId == background.SceneId).FirstOrDefault();
            currentBackground.Img = background.Img;
            currentBackground.Colour = background.Colour;
            _context.Set<VRBackground>().Update(currentBackground);
            _context.SaveChanges();
        }
    }
}
