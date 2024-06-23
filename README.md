# Assignment2

J1Controller - The New CCC (Canadian Calorie Counting)

Description
This controller solves the J1 problem of calculating total calorie counts based on selected menu items. It provides an endpoint that accepts indices for a burger, drink, side, and dessert, calculates the total calories, and returns the result.

Endpoint
GET /api/J1/Menu/{burger}/{drink}/{side}/{dessert}

burger: Index of the burger choice (1-4)
drink: Index of the drink choice (1-4)
side: Index of the side choice (1-4)
dessert: Index of the dessert choice (1-4)
Example Usage
Request: GET /api/J1/Menu/4/4/4/4

Response: Your total calorie count is 0
Request: GET /api/J1/Menu/1/2/3/4

Response: Your total calorie count is 691
Setup Instructions
Clone this repository.
Open the solution in Visual Studio (or any preferred IDE).
Build and run the application.
Use a tool like Postman or your web browser to make GET requests to the endpoint specified above.


J2Controller - Roll the Dice

Description
This controller solves the J2 problem of determining the number of ways two dice can roll a sum of 10. It provides an endpoint that accepts the number of sides for two dice, calculates the possible combinations, and returns the result.

Endpoint

GET /api/J2/DiceGame/{m}/{n}

m: Number of sides on the first die
n: Number of sides on the second die


Example Usage
Request: GET /api/J2/DiceGame/6/8

Response: There are 5 total ways to get the sum 10.
Request: GET /api/J2/DiceGame/12/4

Response: There are 4 total ways to get the sum 10.
Request: GET /api/J2/DiceGame/3/3

Response: There are 0 total ways to get the sum 10.
Request: GET /api/J2/DiceGame/5/5

Response: There is 1 total way to get the sum 10.
Setup Instructions
Clone this repository.
Open the solution in Visual Studio (or any preferred IDE).
Build and run the application.
Use a tool like Postman or your web browser to make GET requests to the endpoint specified above.
