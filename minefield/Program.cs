//Import Player class and declare object
Player totoshka = new Player("Totoshka", 0, 0);
Player ally = new Player("Ally", 0, 0);

//Init 2D array | √ = safe path | X = bomb | O = unknown
String[,] minefield = { {"O", "√", "X", "X", "O"}, 
                      {"X", "X", "√", "X", "O"},
                      {"O", "X", "X", "√", "X"},
                      {"X", "O", "X", "√", "X"},
                      {"O", "X", "√", "X", "X"}
                      };
                                
            //Init printing the MineField
            for (int i = 0; i < minefield.GetLength(0); i++){
                Console.WriteLine();
                for (int j = 0; j < minefield.GetLength(1); j++){
                    if (minefield[i, j] == "√"){
                        Console.ForegroundColor = ConsoleColor.Green;
                    }else
                    if(minefield[i, j] == "X"){
                        Console.ForegroundColor = ConsoleColor.Red;
                    }else{
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(minefield[i, j] + " ");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

            //Start the game
            int lastColumn = 0;
            for (int currentRow = 0; currentRow < minefield.GetLength(0)+2; currentRow++){
                Thread.Sleep(1000); //Add delay
                    if(currentRow == 0){
                        lastColumn = TotoshkaTurn(currentRow);
                        Location();
                    }else if(currentRow > minefield.GetLength(0)){
                        AllyTurn(lastColumn);
                        Location();
                    }
                    else{
                        AllyTurn(lastColumn);
                        lastColumn = TotoshkaTurn(currentRow);
                        Location();
                    }    
            }
            
            //Function for Totoshka turn and return Totoshka last column
            int TotoshkaTurn(int currentRow){
            Console.WriteLine("\n\n================================================");
                for (int i = 0; i < minefield.GetLength(1); i++){
                    try{
                    if (minefield[currentRow, i] == "√"){
                        Console.WriteLine("Totoshka found a safe path at row: " + currentRow.ToString() + " column: " + i.ToString());
                        totoshka.Column = i;
                        totoshka.Row = currentRow;
                    }
                    }catch(IndexOutOfRangeException){
                        totoshka.Row +=1;
                    }
                }
                return totoshka.Column;
            }

            //Function for Ally turn
            void AllyTurn(int lastColumn){
                for (int i = 0; i < minefield.GetLength(1); i++){
                    ally.Column = lastColumn;
                    ally.Row = totoshka.Row;
                }
            }

            //Print location in minefield
            void Location(){
            for (int i = 0; i < minefield.GetLength(0); i++){
                Console.WriteLine();
                for (int j = 0; j < minefield.GetLength(1); j++){
                    if (i == totoshka.Row && j == totoshka.Column){
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("T ");
                    }else if (totoshka.Row != 0 && i == ally.Row && j== ally.Column){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("A ");
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(minefield[i, j] + " ");
                    };
                }
            }
            Console.WriteLine("\nT - Totoshka   A - Ally");
            }

          







