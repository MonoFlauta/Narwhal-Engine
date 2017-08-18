using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine
{
    class AnimatedObject
    {
        public AnimatedDisplayObject animatedDisplayObject;
        public AnimationController animationController;

        /// <summary>
        /// Creates an animated object
        /// </summary>
        /// <param name="animatedDisplayObject">AnimatedDisplay object</param>
        /// <param name="animationController">Animation controller</param>
        public AnimatedObject(AnimatedDisplayObject animatedDisplayObject, AnimationController animationController)
        {
            this.animatedDisplayObject = animatedDisplayObject;
            this.animationController = animationController;
            animatedDisplayObject.currentAnimation = animationController;
            Narwhal.instance.updateManager.AddCallBack(animationController.Update);
        }
    }
}
