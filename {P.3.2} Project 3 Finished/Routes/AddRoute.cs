using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    class AddRoute : Route
    {
        public AddRoute(string path, Route next = null) : base(path, next) {}
        //will be in all following route classes, it is what will be returned is what the path wants.
        public override int HandleRequest(int i)
        {
            return i + 8;
        }
    }
}
