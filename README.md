# Library Management System

## Introduction

Library  Management  System  is  developed  in  Visual  Studio  using  C#  using  MVC architecture  with  Entity  Framework  code  first  approach. The  system  allows  the  users  to  save  the  details  of  an  author,  publisher,  press,  books,  book copies,  members  and membership  details.  The  user  can  provide  a  book  on  loan  through  the system and also return the book that has been loaned out to a member. The system calculates total  amount  of  penalty  charge  if  the  date  of  return  has  crossed  the  due  date  for  the  loan  of that particular book copy.The system also  generates a list of the old book  copies that are more than 365 days old and provides functionality to delete these book copies. The system also generates a list of inactive books  and  members  which  have  not  been  loaned  out  in  the  recent  31  days  or  the  members which have not loaned a book in a long time.


## Installation

1. Clone the project.
```bash
git clone https://github.com/nikhil-pandey/library-management-system
```
2. Open `LMS.sln` using Visual Studio.
3. Install packages using NuGet. Open package manager console and enter the following command
```bash
Update-database
```
4. Compile and build the program and run the program.


## Screenshots

![Imgur](https://i.imgur.com/osuXm22.png)

![Imgur](https://i.imgur.com/ExNPRQE.png)

![Imgur](https://i.imgur.com/FlTkkR1.png)

![Imgur](https://i.imgur.com/U0oNSh2.png)
