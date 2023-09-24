### FarmVision

# Inspiration
We wanted to work with John Deere Precision Ag APIs, and we also had a Quest 2 virtual reality headset at our disposal. The API provided satellite image layers which we thought could be nicely modeled in a 3D environment.

# What it does
Our Project models field operation data representing various measurements (Moisture levels, Harvest yield, etc.) in an interactive VR environment.

# Technologies used
[![My Skills](https://skillicons.dev/icons?i=unity,cs,postman&theme=dark)](https://skillicons.dev)

# How We Built It
1: Created an Operations Center account and acquired John Deere sample operational data <br>
2: Used Postman to collect data from several fields by utilizing Deere Precision Ag APIs <br>
3: Created a 3D environment in Unity to overlay heatmaps onto satellite imagery & incorporated interactivity <br>
4: Modeled data in 3D by extruding cubes vertically depending on each pixel color value. <br>
5: Built & ran project on Oculus Quest 2 VR headset

# Challenges we ran into
Didn't have access to some APIs for certain requests <br>
Difficulty configuring VR headset to a laptop with a graphics card that meets specifications <br>
Security issues with API authorization
