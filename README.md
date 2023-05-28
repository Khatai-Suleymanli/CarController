## Wheels Controller

The `WheelsController` script is responsible for controlling the wheels of a vehicle in a Unity game. It provides basic functionality for accelerating, braking, and steering the vehicle. Additionally, it handles the audio and player interaction aspects related to the vehicle.

### Features

- Wheel collider references and transforms for each wheel of the vehicle.
- Customizable acceleration, braking force, and maximum turn angle.
- Audio support for engine sound.
- Player interaction to enter and exit the vehicle.
- Smooth wheel rotation and position updates.

### How it Works

The `WheelsController` script controls the movement and behavior of the vehicle by interacting with the wheel colliders and transforms. The main steps involved in the process are as follows:

1. Setting up references: The script requires assigning the appropriate wheel colliders and transforms for each wheel of the vehicle in the Unity Inspector.

2. Handling player interaction: If the player is near the vehicle and presses the "E" key, they can enter or exit the vehicle. This is controlled by the `inCar` boolean variable and the `Player` game object.

3. Controlling acceleration and braking: When the player is inside the vehicle, the script reads the input from the vertical axis ("Vertical") to control the acceleration. The acceleration value is multiplied by the input value and stored in `currentAcceleration`. The braking force is controlled by the "Space" key. If the key is pressed, `currentBrakeForce` is set to the defined `breakingForce`; otherwise, it is set to zero.

4. Steering the vehicle: When the player is inside the vehicle, the script reads the input from the horizontal axis ("Horizontal") to control the steering angle. The input value is multiplied by the defined `maxTurnAngle` and stored in `currentTurnAngle`. This value is applied to the front wheel colliders to steer the vehicle.

5. Updating the wheel positions and rotations: The `UpdateWheel` function is called to update the position and rotation of each wheel transform based on the corresponding wheel collider. This ensures that the visual representation of the wheels accurately reflects their physics-based behavior.

6. Handling audio: The script uses an `AudioSource` component to play the engine sound. The audio volume and pitch are adjusted based on the vehicle's speed to create a more immersive experience.

### Getting Started

To use the `WheelsController` script in your Unity project, follow these steps:

1. Attach the `WheelsController` script to the game object representing the vehicle in your scene.

2. Assign the appropriate wheel colliders and transforms for each wheel of the vehicle in the Unity Inspector.

3. Adjust the `acceleration`, `breakingForce`, and `maxTurnAngle` parameters to achieve the desired vehicle behavior.

4. (Optional) Customize the audio settings by modifying the `AudioClip`, `AudioSource`, and related code.

5. Run your game and control the vehicle using the assigned input controls.

### Notes

- The script assumes the player is controlled by the Unity Input System using the "Vertical" and "Horizontal" axes. Make sure your input system is configured accordingly.

- The script assumes the player game object can be enabled and disabled using the `SetActive` function.

- Ensure that the wheel colliders are properly configured and aligned with the vehicle's wheels to achieve realistic physics-based behavior.
