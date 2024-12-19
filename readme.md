# **README: AR Maze Game Project**



### **Group Members**  
- Ahmad Zubair Rahimi 21050141006  
- Ali Şen 20050111066
- Hidayet Aktürk 20050111030
---

## **Description**  
This project is an AR-based maze game built in Unity. The game uses AR features to track player movement and provides an immersive experience. The player navigates the maze, and their performance is tracked using a timer. The game includes start, gameplay, and end scenes with a star-based performance system.

---

## **Features**

### **1. AR Integration**  
- Utilizes Unity’s AR Foundation for augmented reality functionalities.  
- Tracks the player's movement using the XR camera and AR session.  

### **2. Gameplay**  
- **Player Movement**: Player cube movement controlled by head tilt using the XR camera.  
- **Collision Detection**: Prevents movement through walls and resets position upon invalid movement.  

### **3. Timer System**  
- Tracks elapsed gameplay time using a `TimerController`.  
- Displays the timer dynamically on screen during the game and on the end scene.  

### **4. Star Display System**  
- Based on gameplay performance, stars are shown on the end scene:  
  - **3 Stars**: Best performance.  
  - **2 Stars**: Moderate performance.  
  - **1 Star**: Needs improvement.  

### **5. Scenes**  
- **Start Scene**: Displays a start button to begin the game.  
- **Gameplay Scene**: The main maze where the player navigates.  
- **End Scene**: Shows results with a star rating and a "Try Again" button to restart.  

---

## **Setup Instructions**

1. **Unity Requirements**:
   - Unity version: **2021.3+** (or compatible with AR Foundation).  
   - Install **AR Foundation** and **AR Core XR Plugin** via the Unity Package Manager.  

2. **Scene Management**:
   - Ensure the following scenes are added to the build settings:
     - **Start Scene** (`scene index 0`)  
     - **Gameplay Scene** (`scene index 1`)  
     - **End Scene** (`scene index 2`)  

3. **GameObjects Setup**:
   - **Player Cube**: Assign a GameObject as the player's in-game avatar.  
   - **XR Origin**: Add to the scene for AR tracking (ensure it includes the camera and AR session).  
   - **UI Elements**:
     - Timer display (`TextMesh` or `Text`).  
     - Star images (`Image` or `GameObject`).  

4. **Script Assignments**:
   - Attach `TimerController` to a persistent GameObject to manage time tracking.  
   - Attach gameplay scripts (e.g., movement, collision detection) to appropriate objects.  

---

## **Gameplay Instructions**

1. **Start Scene**:
   - Press the "Start" button to begin the game.  

2. **Gameplay Scene**:
   - Navigate through the maze by tilting your head (camera tilt detection).  
   - Avoid walls and obstacles.  

3. **End Scene**:
   - View your performance and star rating.  
   - Press "Exit" to quit the game.  

---

## **Star Display Logic**

| Time Elapsed (seconds) | Stars Displayed |
|-------------------------|-----------------|
| ≤ 40                   | 3 Stars         |
| > 40 and ≤ 50          | 2 Stars         |
| > 50                   | 1 Star          |

---

For further assistance or feature requests, feel free to enhance the scripts or contact the development team!
