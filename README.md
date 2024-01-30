# Unity Fire Extinguishing Simulator

## Description

This is a project for a fire extinguishing simulator in Unity. It includes a set of scripts and functionalities that allow for interactive extinguishing of a virtual fire using a fire extinguisher. The project features mechanics such as extinguisher height adjustment, fire extinguishing, visualization of extinguisher powder, as well as dynamic visual and sound effects.

## Features

- **Fire Extinguisher**: Allows interactive fire extinguishing with animations and sound effects.
- **Fire**: Simulates fire behavior, decreasing when extinguished and increasing when left unattended.
- **UI**: Displays the state of the extinguisher and the level of the fire, including a slider to adjust the extinguisher's height.
- **Sound Effects**: Plays sounds associated with the extinguisher's use and the fire.
- **Line Renderer**: Creates a visual representation of the fire hose connecting the extinguisher to the nozzle.

## Requirements

- Unity 2020.3 or later
- Particle system for fire and extinguishing powder effects

## How to Run

1. Clone the repository or download the project.
2. Open the project in Unity.
3. Run the `SampleScene` scene to test the functionalities.

## Scripts

- `Extinguisher.cs`: Manages the fire extinguisher's functionality, including fire extinguishing and powder management.
- `FireBehavior.cs`: Simulates fire behavior, including reaction to being extinguished.
- `LineController.cs`: Creates a visualization of the fire hose.
- `ExtinguisherPowderUI.cs`: Updates the UI based on the extinguisher's status.
- `ExtinguisherHeightController.cs`: Adjusts the extinguisher's height using a UI slider.
- ... (other scripts as needed for the project).
