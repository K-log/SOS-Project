- [Home](/README.md)
- [**Journal**](/journal.md)
- [Features](/features.md)
- [Timeline](/timeline.md)
- [Proposal](/proposal.md)
- [Code Samples](/codesamples.md)
- [Bibliography](/bibliography.md)


Winter
---

### Week 1
  Nauy: Create the player movement animations which include include walking Left/Right/Back/Front.

  Noah: Create the Player movement Script and learn how to control animation from the script. 
  
  *Things we have completed:*
  Create the player movement animation and Player movement Script that allow us to control the Player on keyboard
  
  *Issues we have run into:*
  - [x] Controlling the player animation changes from the script and within the animation controller. 
  - [x] Creating a Tilemap/game map. This depends on if/what external software we use apart from unity and where we're at as far as art assets.  

### Week 2
  Nauy: player movement animations which include include attacking Left/Right/Back/Front.

  Noah: Create the Player movement and attacking Script.
  
  *Things we have completed:*
  Controlling the player animation with moving and attacking connect with working script.
  
  *Issues we have run into:*
  - [x] The animation working with the moveement and attacking but it still has some delay time when switching between each animation.
  
### Week 3
   Noah: Add title screen	display script to make the title screen the same size regardless of the screen size.		
   
   Nauy: Add title screen	Write script to make the title screen link with other StartGame/Howtoplay/Quit/Credits/Backtomenu
   
   
   *Things we have completed:*
  - Successfully link all screens in the main menu with each other.
  - Transitioned to 2D sidescroller format. This will allow us to focus more on gameplay elements and less on having to draw assets.
  
  
  *Issues we have run into:*
  - [x] The player follow camera is not as precise as we would like and needs some minor adjustments.
  - [x] We need to clean up our project working directory and start moving away from doing all our testing in the working directory as we begin to add more perminent elements to the base game components.
  

### Week 4
  Noah: Added movement; Walking left and right and jumping. Made the player follow camera faster.
    
  Nauy: Added Completed start screen and started basic UI setup. Fixed a bug in the player follow camera.
    
  *Things we have completed:*
    - Successfully completed player walking left and right and player jumping.
    - Successfully completed the menu and start screen.
    
  *Issues we have run into:*
  - [x] We broke the animation system while getting the movement to work so that needs to be fixed.
  - [x] Wall and double jumping still needs to be fixed. Currently wall jumping semi works but it still has a ways to go.
  - [x] We need to optimize the code to make it more responsive.
    
    
    

### Week 5
  Noah: Rewrote the entire movement system and found some premade assets to test it with.
    
  Nauy: Added script for player health bar/ enemy chasing player 
  
  
  *Things we have completed:*
  
   - Successfully completed enemy follow attack script and player health bar. 
   - Successfully completed the menu and start screen.
   - Successfully got the movement more responsive so there is no more lag or jiter in the controls.    
  
  *Issues we have run into:*
  - [x] Minor issues with wall jumping needing to be fixed to work with the new player movement script.
  - [x] About a week or two behind schedule but now that the code has been cleaned up it should be easier to make more progress.
    
### Week 6 and Week 7
  Noah: Finished rebuilding the player movement system and built a test level and started on creating some assets for the player. Cleaned up the project again. Added a lot of documentation to the scripts.
  
  Nauy: finished player health bar/ enemy chasing player now attacking( or touching player) and health bar will drop also with some traps that every time player hit the trap it will cost damage to health bar
  
  *Things we have completed:*
  
   - Player Movement is finally done. This includes: Walking, Jumping, Longjumping, WallJumping, Crouching, and Running.
   - We have a temporary camera follow script working.
   - Reorganized the project in such a way as to make future work go a lot faster(Just broke everything up into smaller, more modular, scripts).
   - Added a lot of documentation to the scripts to make it easier to go back and continue working on them.
    
   *Issues we have run into:*
   - [x] Now only a week behind. 
   - [ ] Camera follow script works but needs some tweaking so it doesnt show things that are off the screen.
   - [ ] The player assets need a lot of work.
   - [ ] The emeny and trap really needs to have cool downtime after each attack(touch)

### Week 8
   Noah: Found and started using the program Tiled to make the map instead of the default usinity editor. Fixed a health bar issue     where they wouldnt have appeared on different resolution screens.
   
   Nauy: Working on adding player enemies as well as Objects within the game world.

### Week 9
   Noah: Done some design work on player character concept art and various items as well as started research on how to implement the player item system.
   
   Nauy: Did some finishing work as I will be leaving sos this quarter so Noah can continue on with the project on his own.
   
   
   *Issues we have run into.*
   - [x] The map editor we were using hasnt been working so Noah is building a new one from scratch in unity.
   - [x] The map is broken so now we have a game but no map.
   - [ ] Still need to add player items and combat.
   
### Week 10
   Noah: Focused mainly on completeing other work in SOS but got a little more done with the level editor. Started writing next quarters timeline.



Spring
---
Nauy has left the program so I will continue working on the project by myself.


### Week 1
 - ~~Updated the wall jumping mechanic so now the player has to jump between two walls as opposed to just being able to jump up a single wall.~~
 - Created a new level using unity's tile map instead of the custom one I will building (Tilemap support was added to unity in one of the more recent version hence the reason I was working on building a tilemap).
 - Started work on a new dash movement ability and on creating character assets.
 - Added debug character animation for wall slide where the debug player now shows which side of it is touching a wall.
 

### Week 2
  - Created a new player character! *Thanks to Michelle(Hope I spelled this right) for all their help with Photoshop*!
  - The new level I created the week before in now too small for the new character so I will need to create a new one.
  - All the animations are broken due to the new character so those need to be fixed too.
  
### Week 3
  - Fixed all the animations so now they are all fully functional again. Walk, Jump, Idle, Wallslide all work now with the new player assets but crouch still needs to be fixed although due to the nature of how the crouch behavior was coded I may leave it out. 
  - remade the test level to better suit the new player character. It is now much bigger and doesn't feel as cramped.
  - Added a sword for the player character.
  - Now working on getting combat animations to work.
 
### Week 4
  - Figured out how to do most of the combat for the player so now just working on making all the player's combat animations. 
  - I haven't figured out a simple way to added a sword to the preexisting animations so I will essentially be copy and pasting all the animations and adding a sword to them.
  - I have decided to leave the dash ability for later as combat is more important at the moment.
### Week 5
  - While searching for an efficient way to do combat animation I stumbled on a simpler way to do animations all together. Anima2d is an asset package for Unity that allows you to build bones and rigging for sprite based characters and then allows you to menipulate them to create animations more easily and a lot quicker than having to move all the components around individually.
  - I rigged and reanimated the character 
  - Built a complete level that is about the size I'm aiming for for each level. 
      - The Level also features some traps and a sword item to pickup.
      - Will add enemies later
  - Unfortunately when reanimating the character, it broke the movement a little so that now needs to be fixed but I believe I am much close to getting combat animations working.

### Week 6
  - Refactored the project to remove unnecessary clutter and left over assets from debugging and testing earlier in development.
  - Fixed all the character animations so they work with the user's input.
  - Changed some of the ways movement works:
      - Now when the player is falling their horizontal movement is slowed.
      - When jumping, the jump animation doesnt repeat and stops at the end until a new moement state occurs.
      - Changed the gravity scale, jump height, movement speed to make the character slower and move easy to control.
  - Fixed the main menu so now the back buttons are more easiy accessable.
  - Added a script so now the hostile objects in the world can damage the player.
  - Have now decided to make the character shoot projectiles instead of using a sword.
  - Mana bar now goes down while shooting.
  - Added an enemy that follows the player and damages them on each hit.
### Week 7
  - Mana bar and health regenerate while not shooting/being hurt
  - There is now a semi-functional pause menu
  - Enemies should now consistently hurt the player instead of just on first contact
### Week 8
  - Finishing up and making sure the game is still playable as well as deciding which features to finish and which to remove if not completed.
  - Collecting parts(code, screenshots, etc.) to use for final presentation. 
### Week 9
### Week 10
