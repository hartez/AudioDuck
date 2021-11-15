# AudioDuck

AudioDuck is a MAUI application that toggles the music volume of the device between two preset values.

It currently only works on Android (because that's the only platform I immedidately needed). But making it work on other platforms is just a matter of implementing IMusicVolumeService.

## Why?

I had a need for an easy way to switch music volume from loud to soft and back on a device that's playing to a Bluetooth speaker. I needed to duck the volume instantly without having to bring up the normal volume dialogs or pick up the device and hit the hardware volume buttons.

With this, I can set the high and low volumes, then tap the very large volume toggle button to switch.

