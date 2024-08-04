
## Overview:

Welcome To The Student Database, This Project Represents My 1st-Year Programming Assignment For The BSc (Hons) Cyber Security & Digital Forensics Course. In Which I Fulfilled A Scenario To Create An Object-Oriented C# Computer Program For A University. The Program's Primary Function Is To Facilitate The Entry And Management Of Student Marks

## Scenario:

You Have Recently Been Employed As A Junior Software Developer For A Tech Company And You Have Been Given Your First Individual Project To Complete. Your Company Have Tasked You With Creating An Object Oriented C# Computer Program For A University To Allow Marks To Be Entered

## User Interaction:

The Program Initiates By Presenting The User With A Set Of Menu Choices:

1. [Create A New Student Record](#creating-a-new-student-record)
2. [Enter Marks For A Student Record](#entering-marks-for-a-student)
3. [Update A Student’s Marks](#updating-a-student-record)
4. [Show A Student Record](#viewing-a-record)
5. [Quit The Program](#quitting-the-program)

## Creating A New Student Record:

- The User Opts To Create A New Student Record
- The System Generates A Unique 8-Digit Student Number
- The User Provides The Student’s Name
- After Confirmation, The Program Creates And Saves The New, Empty Student Record

## Entering Marks For A Student:

- The User Chooses To Enter Marks For A Student
- The System Prompts For A Student Number And Searches For The Corresponding Record
- If Found, The User Inputs 6 Different Marks (Validated Between 0 And 100)
- The Program Calculates The Average Of The Marks And Adds A Pass/Fail Note Based On A 40 Threshold
- If The Record Doesn’t Exist, The User Is Notified

## Updating A Student Record:

- The User Selects To Update A Student Record
- The System Prompts For A Student Number And Searches For The Record
- If Found, The User Inputs 6 Different Marks, And The Average Is Calculated
- The New Information Is Appended To The Existing Data, Preserving The History
- If The Record Doesn’t Exist, The User Is Notified

## Viewing A Record:

- The User Chooses To View A Record And Inputs A Student Number
- If The Record Exists, All Details Are Displayed; Otherwise, An Error Message Is Shown

## Quitting The Program:

- The User Decides To Quit The Program

## License:

This Project Is Licensed Under The [GNU General Public License V3.0](LICENSE). Adherence To The Terms And Conditions Of The License Is Required.
