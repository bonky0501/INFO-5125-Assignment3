using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    //just the server interface
    interface AbstractServer
    {
        bool isAvailable();
        void IncomingRequest(Request request);
        void Run();


    }
}
