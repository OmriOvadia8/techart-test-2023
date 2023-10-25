# Technical Artist Home Assignment by Omri Ovadia

## Brief
For this task, I remade the popup prefab, incorporating effects and animations to enhance its visual appeal.
Working on this project was a delightful experience. I learned new concepts and techniques, and it was enriching.
I placed emphasis on ensuring elements were both adjustable and scalable directly from the Unity Inspector, allowing users to easily customize features while ensuring the popup updates accordingly.

## Decision Making Process
### Dynamic Elements
To offer flexibility, I designed most elements to be adjustable and scalable.
The main example is tweaking settings via the Unity Inspector like changing the Score Multipliers' values will affect the popup content accordingly (Changing positions, texts, alpha, calculations, etc..).
I replaced all the text from the PSD with TextMeshPro, except for the "Victory" text, allowing greater flexibility with the popup's text content.
Given that the "Victory" text has limited variations and its style in the PSD is intricate to replicate in TMP, I used the image directly from the PSD.
This ensures both quality and easy updates through the ArtReplacerTool.

### Animations
I employed DOTween to script all animations, except for the Open/Close ones.
Users can adjust animation parameters (like speed and scale) through the Unity Inspector.
Although I contemplated adding animations like spinning Sun Beam and additional particles, I decided against overloading the design and aimed for subtlety.
The initiation of DOTween animations is triggered by Unity Animation Events after the popup's opening animation completes.
I referred to the "Resort Kings" game to draw inspiration from the original popup.

### Elements Positions
I've anchored all elements to ensure consistent positioning across a range of portrait screen resolutions, spanning from large screens of flip phones to screens as small as the Redmi4.
I ensured the Score Info lines' positions (Super, Bet, War) are being adjusted via Grid Layout in case some of them aren't activated.

## Challenges
While I didn't have extensive experience in crafting window editor tools, with online resources and dedicated learning, I successfully created the Art Replacer Tool.
