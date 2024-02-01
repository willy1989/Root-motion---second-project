https://github.com/willy1989/Root-motion---second-project
## Project Goals

The goal of the project was to create a character controller based on root motion, enabling the player to execute simple movements such as walking, running, jumping, and turning around. The environment consists of just two platforms, without any obstacles or enemies, representing a character controller in its most basic form.

## Code Structure

I opted to create a state-machine system, with each state encapsulating its own logic, including the actions performed each tick and the conditions for transitioning to another state.

The state classes all inherit from Unity’s built-in StateMachineBehaviour class.

Additionally, I developed helper classes whose functionalities are utilized across the states:

- AnimationManager (controls the actual animations)
    
- FallMovement
    
- InputManager
    
- CharacterTransformManager (used for making slight adjustments to the transform and checking its state)
    

  
## Unity’s built-in state machine system.

  

Pros:


- Visual representation allows us, in theory, to track the current state and understand transitions between states.

Cons:
  

- The setup is awkward because instances of MonoBehaviour classes, which are used for the game’s logic (movement, input check, etc.), must be accessed through the animator. This limitation arises because instances of StateMachineBehaviour cannot obtain references from a MonoBehaviour class instance in the scene.

- The system becomes complex with many states and transitions, making it difficult to understand the relationships between states.
    

![](https://lh7-us.googleusercontent.com/K8M0iQbyOHL-jaisj8DM_sJ-D3YB-siNeKrtDW0BY8lTShxi7xdEVxbefc1Qi4o2d5e9sbZDu654lm-elezNSWTR70kRZhDmT3K9vPyvj65X8x2mkm4ugyUsQbi_gHOXThTz3T_S8u_Xh8tt0zH89FI)

  

Transitioning between states requires manually setting up and updating triggers in the editor, which adds maintenance costs and coupling. This complexity undermines the potential benefits of a clear visual representation, with additional states only increasing the visual clutter.
## Challenges

### Imprecise Movement of Root Motion Animation

Working with animations not tailored to my specific needs presented challenges. I had to correct or clean up the position and rotation of the character through the TransformManager class. Otherwise, the model would behave unpredictably, such as not turning exactly 180 degrees on the y-axis during a turn animation or clipping through walls. This suggests that root motion animations may inherently struggle to position the character perfectly due to the movement mechanics of the bones.

Additionally, a falling animation did not move the character downward, prompting me to create a class that allowed for this movement, thus deviating from the principle that character movement should be driven by animation.

### Conflicts Between Root Motion and Scripting

Conflicts arose when transitioning to a new state; cleaning up the transform within the OnStateExit method was problematic because the current animation could overwrite the changes made to the character's transform with TransformManager. 

![](https://lh7-us.googleusercontent.com/GTB8w3FWAgJCTau-zvEVVJCUyigkwZrjpmNNjdI-R3e0Xj6edqwQGL6_bJiHA_1Nojd2_XoL-7eKAIpy5YSY7q8hLlNhd9_6ISXA7BnktliKjw-DfNvDQV8Ibvi6u6Sk_gQ--SUgtWImKt4gcBfuf70)

To address this, I called the transform cleanup methods, like ResetXPosition(), at the end of the frame. 

![](https://lh7-us.googleusercontent.com/SwtzntRS0RM90ACpgoZj2D8nMCdgpSnu-TALOIPpr_ot2kjckA1w_gSmpgfv-e6vyHwnM6KKDhJzkegoS4kVODoXa6tuiQV3Jn2f4r55nqkgcfcW8tDScMdXIXJe7lkFC1M6NhZA3NI28MPgxYC3CZw)

Although this fixed the issue, it felt like a workaround rather than a satisfactory solution, because it wasn’t clear in which order the OnStateExit, and the animation update would take place.
### Gradual Transitions

Immediate state transitions contrasted with the gradual transitions between animations, creating a disconnect. For example, the AnimationManager class's IsCurrentAnimationRunning method could indicate a transition from state A to state B while the animator was still playing the previous animation. 

![](https://lh7-us.googleusercontent.com/loJnXFNCW_fUReGVVnMV9zhaR0_3GNBtCMWLOWefzIBy6yL5ySRHGYajqNqomX2N8mj3NgM231Ka3zS_ltWA1AsD4oZjZrGyzPh8lKjWVmw1B9D5Twkx40u91ngyAHBZESIUYHIGKipO3n664gp85Zo)

State B checking the state of the current animation (still animation A at this time):

![](https://lh7-us.googleusercontent.com/pdYOWrTGeGcJ4kwgbivIX8HsKPNDM_cp-ouHaiRqdiHlX7EjfcVFOTbCjgbVUq-_P0EZuz5v7PNNiHAC-MzSu4k4p6FdIe9Ws2GcPT7ep-AOXD0qyUmI17X--Ziy_VTse8ooWrlEaaTr-o1zhJpEGaQ)

This mismatch meant the intended animation for state B was never played, leading to a direct jump to state C. 

As this bug remains unsolved, I decided to switch from one animation to another immediately.

## Considerations for the Next Iteration of the Project

- Investigating whether animations perfectly tailored for root motion could eliminate the need for transform corrections.
    
- Identifying the precise causes of conflicts between root motion and script-based transform changes and exploring cleaner solutions within the animation/state system.
    
- Considering whether to abandon Unity’s state machine system or any visual representation of the system due to the complexity and maintenance demands introduced by just ten states.
    
- Addressing the gradual animation bug, possibly by checking if the animator is still transitioning (using animator.IsInTransition()).
    
