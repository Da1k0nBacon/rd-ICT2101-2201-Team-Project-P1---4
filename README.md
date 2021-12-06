ICT2101-Team-P1-4 Robot Car Website System Project.

# Project Overview
> <p style="text-align=justify">The Robot Car Website System is intended for primary school students to use solely for education purposes. The system deployed is an online web interface where students can easily access it using desktops or laptops. This project will be a follow-on product based on products such as Lego Mindstorms, however it is improved as for example with Lego Mindstorms, the programming needs to be done via connecting to the computer via a cable while for the Robot Car Website System, programming can be done wirelessly via Wi-Fi. The online web portal will be the central interface used by students to send commands to control the movement of the robot car and receive feedback on the robot car. Feedback received will be displayed out via the web portal. Also, on the web portal a student can create a profile while there will be a teacher account that will be able to check on the student’s progress and create challenges for students to complete. <br/>

> Students must click on different car movement commands on the web portal to move the robot car successfully. Commands will then be stored on the server and sent over the internet to the car through an ESP8266 Wi-Fi serial transmitter. From the external point of view, the car's built-in sensors will detect and change according to the commands indicated by the students. The sensors will then drive the robot car to exhibit various behaviours. These behaviours will reflect on the web portal through transferring data using Wi-Fi and server. </p>

<p align="center">
<img src="https://user-images.githubusercontent.com/73220938/140599125-addbd92f-0603-4312-94f7-5709214a5f5e.JPG" width="800" height="400">
</p>

# Resources
* Review [Wiki](https://github.com/Da1k0nBacon/rd-ICT2101-2201-Team-Project-P1---4/wiki) for more information about the project and team management

# Workflow
<h1>Rules</h1>
<p style="text-align=justify"> The team has agreed to commit changes to their individual branches first, then from there once confirmed, perform a pull request to the main branch. The code is reviewed by the Scrum Master Tiffany and any conflicts is resolved by her</p>

<h1>Master Branch</h1>
<p style="text-align=justify">Only the Scrum Master can merge the pull request to the master branch</p>

<h1>Test Branch</h1>
<p style="text-align=justify">Only testing of code from master branch will be done on this branch. Testing will be done by one of the web developers which will then report to the Scrum Master about the testing</p>

<h1>User Acceptance Test</h1>
<p style="text-align=justify">This tests are derived via the System State Diagram which is made from the Use Case Diagram</p>

<h1>White Box Testing</h1>
<p style="text-align=justify">This is done by first coming up with test cases manually for code coverage</p>

<p style="text-align=justify">After coming up with the code coverage test cases the team came up with test cases for branch coverage</p>

![CFG](https://user-images.githubusercontent.com/73848081/144922546-6de54253-8c70-4001-876c-abfff27c20de.png)

<p style="text-align=justify">Finally the team calculate the Cyclomatic complexity: V(G) = e - n + 2(p) which resulted in 13 - 12 + 2 = 3 paths which shows in order to cover enough paths the team would need to cover at least 3 paths this is shown in the test cases below</p>

