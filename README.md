# GeekTrust.GoldenCrown

Golden Crown Problem 

How to run ?

    ## Command Prompt

        1.Go to the GoldenCrown Directory
        2.Open cmd on that directory
        3.Enter the below command 

            dotnet build 
              (or)
            dotnet build -o 'path where you want to build the project' 
            
        4.If you do not give the path it will be build in bin\debug\netcoreapp3.1  folder
        5.Go to that folder and open cmd 
        6.Enter the below command  

            dotnet geektrust.dll 'input path'

        7.It will show the output in the cmd 
        
        
How to run unittests ?

      ## Using Visual studio
      
            1.Go to the GoldenCrown Directory and open the sln file with Visual studio.
            2.You can see GoldenCrownTests project in solution explorer.
            3.In the visual studio menu go to Test and open Test Explorer.
            4.You can see the test cases and Run option click on it.
            5.It will run the tests and shows the results.
            
      ## Using CMD
      
            1.Go to the GoldenCrown Directory and open the Cmd in that directory
            2.Enter the below command
            
                    dotnet test
            3.It will run the testcases and shows the result.
            
            
      

Note :

    I assumed that the input file has kingdom and msg are separated by tab space.
    

     
