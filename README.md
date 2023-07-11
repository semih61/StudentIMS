# StudentIMS
This is my first web programming project that I currently develop it using ASP.NET Core.
What did I do until now ? :
*I created the tables named student and department using the entity framework.
*I divided the project to layer using N-tier architecture to develop easier in the future.
*I used IRepository and IUniutOfWork design patterns. 
*I used ViewBag, ViewData and TempData data structures but, these structures make it hard to control data transfer if used heavily. So, I created a new layer named Models
after that, I moved models to the models layer.
