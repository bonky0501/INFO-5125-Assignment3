using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    class Route
    {
        private Route Next;
        private string Path;

        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }
        //will be in all following route classes, it is what will be returned is what the path wants.
         public virtual int HandleRequest(int i)
        {
            return 404;
        }

        //checks the other routes, if the path matches one in the CoR then it will do that one, otherwise it will check to see the next 
        //one and if it's null will default to 404
        public int CheckOtherRoutes(Request request)
        {

                if (Path == request.Route)
                {
                    return this.HandleRequest(request.Payload);
                }
                if (Next != null)
                {
                    return Next.CheckOtherRoutes(request);
                }
                else
                {
                    return 404;
                }
            
            
        }


    }
}
