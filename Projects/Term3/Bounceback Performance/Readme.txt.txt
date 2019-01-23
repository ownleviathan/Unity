Unity Version: Unity 2018.2.14f1 (64-bit)

SteamVR plugin for Unity - v1.2.2

HeadSet: Oculus Rift

Time spent to finish the assigment: 10 hours.

Problems:

I had problems when I updated the Steam VR plugin, the lastest version is very different to the version that is used
for this course.

Changed that I applied:

* Enable static and dynamic Batching.
* Set static to the objects.
* Fixed the timestep to 0.0111
* Add rigedbody to moving platform, check on kinetic and uncheck gravity.
* Remove rigigbodies to static objects.
* In the code I changes the respwando objects code and remove instanciate to some methos.
* Changes some functions from update to start.
* Changed lighting to baked.
* MSA 8x enable.
* Setting the rendering path to Forward.
* I just only added one light probes, becuse I see that the current light works fine.
* For all prefabs I checked the option "Enable GPU Instancing", with this little change in all prefabs, finally I 
got the 90 FPS.

Thanks

Edwin Perez

Revision 2:

* Fix the score script, only update when is a collision, I deleted the score script and I consolidated the logic
in the GameManager Script.

* Add the 8x and 4x MSSA for the top three quality settings.
* Add differente lightprobes to the entire scene.


