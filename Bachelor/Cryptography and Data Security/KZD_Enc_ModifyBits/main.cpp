/*
           Избрана пермутация  

    0000 -> 1111       1000 -> 0111       
    0001 -> 1110       1001 -> 0110
    0010 -> 1101       1010 -> 0101
    0011 -> 1100       1011 -> 0100
    0100 -> 1011       1100 -> 0011
    0101 -> 1010       1101 -> 0010
    0110 -> 1001       1110 -> 0001
    0111 -> 1000       1111 -> 0000
*/

#include <iostream>
#include <fstream>

using namespace std;

ifstream inputFile; // Вxоден файл
ofstream outputFile; // Изходен файл

// Функция за четене, редактиране и запис на информация във файл
void readEditWriteToFile() {
     string rName, wName; // Име на файл
     string rStr; // за четене на низ от файл
     char buf; // буфер

     
     cout << "Име на входния файл: ";
     cin >> rName;
     rName += ".txt";
     
     inputFile.open(rName.c_str(), ios::in);
     
     if (inputFile) { 
        cout << "Име на изходния файл: ";
        cin >> wName;
        wName += ".txt";     
        outputFile.open(wName.c_str(), ios::out);
               
        while (!inputFile.eof() && inputFile >> rStr) {
              if (rStr.length() == 5) {
                 for (int i = 0; i < 5; i++)
                     if ((rStr.c_str()[i] >= 'A' && rStr.c_str()[i] <= 'Z') ||
                         (rStr.c_str()[i] >= 'a' && rStr.c_str()[i] <= 'z')) {
                         buf = (int) rStr.c_str()[i] ^ 15;
                         outputFile << buf;
                     }  
                     outputFile << " ";                                  
              } // end if
              else continue;     
        } // end while     
           
        outputFile.close();
        inputFile.close();
        cout << "\nДанните са записани!\n";                   
     }
     else cout << "\nФайлът не съществува!\n";    
}


int main() {
    setlocale(LC_ALL, "BGR");
    
    readEditWriteToFile();
    cout << endl;
    system("pause");   
    return 0;
}
