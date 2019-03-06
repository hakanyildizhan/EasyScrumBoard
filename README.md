# Easy Scrum Board
This is a WPF application that is aimed to make the management of your sprints easier on Team Foundation Server. 

## Motivation
I find the default scrum board on TFS Web Interface pretty slow and inconvenient due to

* TFS having to fetch all fields associated with a Task, most of which might not be relevant for the develoepr at all 
* Many clicks needed to get to the parent Request of a Task, which generally includes more information about an issue than a Task does
* Inconvenient, linear and underutilised UI capabilities, e.g. customized Task cards, hover over a card functionality
* Need to open up the work item and fetch all content just to simply change the state of the item or enter a comment
* ... and so on

Goal of this app is to battle these shortcomings.

## Planned Features

* Users can define the work item fields that they want to display and quickly change on a card without opening the whole work item
* Hovering over a card can bring up additional information, e.g. the parent work item
* Drag-drop work items between states
* What have I done since the last daily standup? functionality that will provide a scheduled or on demand summary

## Development and contributing

Feel free to send pull requests and raise issues.