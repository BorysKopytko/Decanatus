# Decanatus
Modern electronic accounting system of academic groups.
Our project goal is to give the university the opportunity to easily manage all its data: from schedules to marks, from students to lecturers etc. System core is ASP.NET Core 6 (MVC) that gives such benefits as cross-platform, security, performance, open-source and much more.

# Requirements
### Authentication and Authorization:

#### Student:
- Log in with credentials provided by admin.
- Log out.
- Change password.

#### Teacher:
- Log in / log out with credentials provided by admin.
- Change password.

#### Admin:
- View info about users.
- Register teachers/students to the system.
- Assign subjects to users.
- Configure user profiles.
- Assign new roles to the user.
- Change password of users.

#### Guest:
- Can see only the home (login) page.

### User Information:

#### Student:
- View personal information.
- View a list of subjects assigned to the student.
- Filter a list of subjects assigned to the student.
- Can view announcements.
- View schedule.
- Generate PDF from schedule.

#### Teacher:
- View personal information.
- View a list of subjects assigned to the teacher.
- View a list of students related to the subject.
- Filter a list of subjects.
- Enter/edit grades for students.
- Add announcements.
- Can view announcements.
- View schedule.
- Generate PDF from schedule.

#### Admin:
- View schedule.
- Edit schedule.
- Add a new subject to the schedule.
- Delete subjects from schedule.
- Generate PDF from schedule.

## Non-Functional Requirements:

### Performance:
- System response time for login/logout should be within 3 second.
- PDF generation for schedules should be completed within 10 seconds.

### Usability:
- The user interface should be intuitive and user-friendly.
- Accessibility features should be implemented to ensure usability for all users.

### Reliability:
- The system should be available 99% of the time.
- Data backup and recovery mechanisms should be in place.

### Scalability:
- The system should handle a growing number of users and data.
- Scalability tests should be conducted to ensure optimal performance under increased load.

### Compatibility:
- The application should be compatible with major web browsers (Chrome, Firefox, Safari, Edge).
- Mobile responsiveness should be ensured for various devices and screen sizes.

### Maintenance:
- Code should be well-documented for ease of maintenance.
- Regular security updates and patches should be applied.

# UML

# Identity Management


# Architecture
N-Tier architecture, also known as multi-tier architecture, is a software design pattern where the components of an application are organized into layers or tiers, each responsible for specific functionalities. The "N" in N-Tier represents the number of layers or tiers in the architecture, and it can vary based on the specific design and requirements of the application.

MVC stands for Model-View-Controller, and it is a software architectural pattern commonly used for designing and developing user interfaces. MVC separates an application into three interconnected components to promote modularity, maintainability, and reusability of code. 

![image](https://github.com/BorysKopytko/Decanatus/assets/71780594/2e2f310c-ef8b-44c0-bf0c-05d6678948ac)


# Concurrency Pattern
Task-Based Asynchronous Pattern (TAP) is used by our system.
TAP is a set of guidelines and conventions for writing asynchronous methods in .NET, including ASP.NET. It defines how asynchronous methods should be structured, how they should return results, and how they should handle errors.
In TAP, Asynchronous methods are marked with the async keyword.
They return a Task or Task<T> to represent the ongoing asynchronous operation.
The await keyword is used to asynchronously wait for the completion of another task without blocking the thread.

![image](https://github.com/BorysKopytko/Decanatus/assets/71780594/304eb690-f7ef-4dea-bc27-7954e41fc5f0)

And here's an example from our project:

![image](https://github.com/BorysKopytko/Decanatus/assets/71780594/5bf701e9-a7cb-4ef1-a378-ccae2f5a2a9a)

