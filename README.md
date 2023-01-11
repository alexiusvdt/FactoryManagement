### By Alex Johnson

An application for tracking machines and their engineers

## Technologies Used

   * C#
   * ASP.Net 6
   * EFCore
   * MySQL
   * LINQ

## Project Requirements

  *  As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.
  *  As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.
  *  As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.
  *  I should not be able to create an engineer or a machine if the form's fields are empty or contain invalid values.
  *  As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed.
  *  As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.
  *  I should not be able to add a machine to an engineer if there are no machines. Likewise I should not be able to add an engineer to a machine if there are no engineers.
  *  When I access the application, I should see a splash page that lists all engineers and machines.

## Setup/Installation Requirements
 * Clone this repo 
 * Navigate to the `Factory` directory, opening a command line interface
 * Enter `dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0`
 * apply the database migrations by entering `dotnet ef database update'
 * Modify the existing appsettings.json file with your individual username and password where prompted & make sure it is added to your .gitignore
 * run the program with `dotnet run`

## Known Bugs
Once you fix this you'll need to make sure the 7th user story is complete:
I should not be able to add a machine to an engineer if there are no machines. Likewise I should not be able to add an engineer to a machine if there are no engineers.
((add validation))

## License

MIT License

Copyright (c) 2023 Alex Johnson

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.