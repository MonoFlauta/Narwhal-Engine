using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine
{
    class AnimatedObject
    {
        public DisplayObject displayObject;
        public AnimationController animationController;

        /// <summary>
        /// Creates an animated object
        /// </summary>
        /// <param name="displayObject">Display object</param>
        /// <param name="animationController">Animation controller</param>
        public AnimatedObject(DisplayObject displayObject, AnimationController animationController)
        {
            this.displayObject = displayObject;
            this.animationController = animationController;
            displayObject.currentAnimation = animationController;
            Flute.instance.updateManager.AddCallBack(animationController.Update);
        }
    }
}
