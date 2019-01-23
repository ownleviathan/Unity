Unity Version: Unity 2018.2.17f1 (64-bit)

SteamVR plugin for Unity - v1.2.2

HeadSet: Oculus Rift

Time spent to finish the assigment: 2 months

Problems:

I was facing so many problems:

1. The change of Steam VR, I tried to used the new one, but when was release I coun't find a good documentation, 
for that reason at the end I used the previous version.
2. I tried to incorporate new elements, like prefabs to show when I need to teleport, I spent a lot of time trying
to figure out this problem.
3. The validZone (cheating System), in this topic I spent like a 3 weeks, I was using diffent components, at the end
I changed them for collision-triggers.. and works.
4. One of the big changellens is to used oculus, because the course documentation is more focus for vive.

Changed that I applied for best performance:

* Enable static and dynamic Batching.
* Set static to the objects.
* Changed lighting to baked.
* MSA 8x enable.
* Setting the rendering path to Defered(this was rare, because if I used forward the FPS increased a lot).
* I just only added one light probes, becuse I see that the current light works fine.
* For all prefabs I checked the option "Enable GPU Instancing", with this little change in all prefabs, finally I 
got the 90 FPS.

Thanks

Edwin Perez


Submit 2:

Change the name : [CameraRig] to VRCameraRig

