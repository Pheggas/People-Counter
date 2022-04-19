# People counter

## This project was made as my bachelor's thesis in Slovak University of Agriculture

**Note:** Project will be most likely abandoned

## Description
This app is able to count people based on my lightweight algorithm and face detection via Haar cascade from capturing device like webcam.
Whole app is avalible in two languages: Slovak and English. This way you can explore all the features in the GUI.

### Counting algorithm
The idea behind it is splitting capturing area in two parts. One part (ROI - Region Of Interest) is where person needs to be to be counted. Then, when person leaves the capturing area, ROI must be empty (without any people in it) for at least 20 frames (which is almost a second on 30 FPS capturing device; depends on FPS of your capturing device). After then, another person can arrive into ROI to be counted.

### Possibilities
With slight changes, you're able to do many other things like: count people with no visible face for the capturing device, or facial recognition, facial tracking etc.

#### Get in touch
For any questions, just open a issue inside this repo and hopely i'll write you back ASAP.
