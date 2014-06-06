#TV Remote Control

##What This Is
It's a web and console app that can communicate with the Sharp AQUOS line of LED Smart TVs. You can find more details about the TVs [here](http://www.sharpusa.com/ForHome/HomeEntertainment/LCDTV/Models/LC70LE650U.aspx).
Currently these apps support the following commands:

1. Power On
2. Power Off
3. Enable remote commands
4. Input Toggle
5. AV Mode Selection
6. Mute Toggle
7. Volume Up
8. Volume Down
9. Switch to HDMI1
10. Switch to Channel 5

You can always add more commands to this list as needed - grab the Sharp AQUOS LC70LE650U manual and look at all available commands.

##Usage

	tvs.CurrentTvs.SendCommand(Command.TurnOn); //this turns on the TVs (or TV, whatever's in the TV list).

The web app is pretty self explanatory. It's a plain old ASP.NET MVC project with Twitter Bootstrap and single page with four buttons. Clicking on any of the buttons 
will send the command to the TVs. The console app accepts four arguments: on, off, serviceon, serviceoff. The last two commands are specific to our arrangement, 
but they are easy to modify to your own needs.

##Customization
There's a shared class library between the two apps that controls the TCP communication from the app to the TVs. Inside that project is a list of default IP addresses and 
an array of zero-based indexes used to skip over certain TVs if need be. For example if you entered 0 and 5, the first and sixth IP addresses in the list 
will be skipped when sending the TV command. Feel free to enter whatever default IP addresses you want, or provide a runtime evaluated list of addresses to the TVAddresses
class.

