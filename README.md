![CommunixLogo.png](CommunixLogo.png)

# Technical Artist Home Assignment

## Set Up Project

● Download unity 2022.3.x lts

● Fork this repository to your own github account

● Open the project in Unity 2022.3

● You Can use any resources, scripts, plugins, assets you want

● You can learn and use any tools available to you such as

    ○ Google
    ○ Forums
    ○ Facebook
    ○ ChatGPT
    ○ And more

> Questions to: shahar.bar@communix.com

## What & how we test?

● We are checking your Unity General Knowledge

● We evaluate overall organization of your project

● It is very important to us to see good hierarchy arrangement

● Understanding of UI and how it works in Unity is important

● We want to see artistic and stylistic approach to the task

● We would like to see Dynamic elements, animation, scalability and effects

● Texture optimization is very important to us

● Good and clean tool creation and usage is a big bonus


## Tasks - Victory Popup
### Importing from PSD

● In the following [PSD File](OriginalPSD.psd) you will find all materials needed for the task
1. [ ] Slice the different elements (the way you think it should be)
2. [ ] Import the sliced elements to the project using TexturePacker by CodeAndWeb https://www.codeandweb.com/texturepacker

### Building the prefab
● In unity create a prefab for the victory popup
1. [ ] Make sure the prefab will look good on different mobile resolutions (portrait)
2. [ ] Make sure the prefab will look as much as possible like the Mockup
![Mockup.png](Mockup.png)

### Adding Popup Behaviour
● Add the following Script to the prefab [PopupBehaviour.cs](Assets/Scripts/PopupBehaviour.cs) 
1. [ ] Add Animator to the prefab - The script will play all of them
2. [ ] On Play the popup should play Open Animation with trigger "Play"
3. [ ] When the popup is opened all elements are revealed
4. [ ] Pop up stays idle for a couple of seconds - feel free to add idle animations/FX
5. [ ] When Press any of the buttons it will call a Method in the Script called "OnClosePressed()"
6. [ ] On Close the popup should play Close Animation with trigger "Close"
7. [ ] Bonus use shaders to create a nice effect on the popup
8. [ ] Try to use Text Mesh Pro for most of the text as you can

### LiveOpes Replace Popup Art Tool
● Art replacement tool, we need to be able to switch art and create new popups rapidly
1. [ ] Use the popup that you just built as template
2. [ ] Write Editor Window tool that will get a new SpriteSheet as Input
3. [ ] Will Create new prefab and save it in the project with the new art replaced
4. [ ] You can implement it how every you want, it is ok if you put in place some rules such same names in the PSD ect.

**● Commit all changes to your fork and send us the link**

## Useful Links and Resources
1. [ ] [UI Video](https://www.youtube.com/watch?v=HwdweCX5aMI/)
2. [ ] [Shaders 101](https://www.youtube.com/watch?v=T-HXmQAMhG0/)
2. [ ] [Texture Packer](https://www.youtube.com/watch?v=4WcoSMFSYiY)

> Questions to: shahar.bar@communix.com