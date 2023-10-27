using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectoTestKimTumanyan.Effects;

namespace VectoTestKimTumanyan.Images
{
    public class ImageManager
    {
        public List<Image> ApplyEffects(List<ImageWithEffects> images)
        {
            List<Image> changedImages = new List<Image>();
            foreach (var img in images)
            {
                foreach (var effect in img.Effects)
                {
                    //Console.WriteLine(effect.Name);
                }
                changedImages.Add(img.Image);
            }            
            return changedImages;
        }
    }
}
