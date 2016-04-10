#include <iostream>
#include <fstream>
#include <graphics.h>

#define SYM   1
#define PRE   2
#define ESC   0x1b

using namespace std;

typedef struct Item {
        string str;
        Item *next;     
}*Point;
Point HeadA, HeadB, HeadC, HeadD;

ofstream OutputTxt;
int i;

int gd = DETECT, gm;
HANDLE hConsole;

//Създаване на списък - тип опашка (FIFO)
void CreateList( Point &Head ) {
     Point P, Last;
     char ch = 'd';
     int j = 0;
     
     while ( ch != 'n' && ch != 'N' && ch != 'н' && ch != 'Н') {
           SetConsoleTextAttribute(hConsole, LIGHTCYAN);     
           P = new Item;
           cout << endl << "Въведете " << j+1 << "-я елемент: ";
           cin >> P->str;          
           P->next = NULL;
           if ( !Head ) 
              Head = P;
           else 
              Last->next = P;
           Last = P;
           SetConsoleTextAttribute(hConsole, LIGHTGRAY);          
           cout << endl << "Ще продължите ли? ( Y | N ) ";
           cin >> ch;
           j++;
     }
}

//Вмъкване в края на списъка..
void AddItem( string buf, Point Head ) {
     Point P = Head, Q;
                  
     Q = new Item;            
     Q->str = buf;
     Q->next = NULL;
     while ( P->next )
           P = P->next;
     P->next = Q;
}

//Извеждане
void PrintList( Point Head ) {
     Point H = Head;
     while ( H ) {
           cout << endl << H->str;
           H = H->next;
     }
     cout << endl;
}

//Търсене на елемент
bool SearchItem( string buf, Point Head ) {
     while ( Head && buf != Head->str )
           Head = Head->next;
     if (Head){      
        if ( buf == Head->str )
           return true;
     }
     else 
        return false;     
}

//Симетрична разлика
void Sym( Point HeadA, Point HeadB ) {
     Point hA = HeadA;
     
     while (HeadA){     
           if ( !SearchItem(HeadA->str, HeadB) )
              AddItem(HeadA->str, HeadC);
           HeadA = HeadA->next;      
     }
     while (HeadB){     
           if ( !SearchItem(HeadB->str, hA) )
              AddItem(HeadB->str, HeadC);
           HeadB = HeadB->next;      
     }
}

//Пресечение
void Presechenie( Point HeadA, Point HeadB ) {
     
     while (HeadA){     
           if ( SearchItem(HeadA->str, HeadB) )
              AddItem(HeadA->str, HeadD);
           HeadA = HeadA->next;      
     }
}

//Записване на данните от втората операция в текстов файл
void ToTxt( Point Head ) {
     Point H = Head;

     OutputTxt.open( "Output.txt", ios::app );     
     while ( H ) {
           OutputTxt << H->str << " ";
           H = H->next;
     }
     OutputTxt << endl;
     OutputTxt.close();     
}

/*///////////////Graphics/////////////////*/
void GraphicMode( Point Head, int Operation ) {
     int color;
     char buffer[3];
     char *msg;
     int j;

     initgraph( &gd, &gm, "C:\\TC\\BGI" );
     /*Design*/
     setcolor( YELLOW );
     setfillstyle( SOLID_FILL, WHITE );
     bar( 0, 30, 639, 450 );
     rectangle( 0, 30, 639, 450 );
     settextstyle( SANS_SERIF_FONT, HORIZ_DIR, 2 );
     setcolor( WHITE );
     if ( Operation == PRE )
        outtextxy( 200, 0, "Пресечение на множества" );
     else if ( Operation == SYM )
        outtextxy( 220, 0, "Симетрична разлика" );
     outtextxy( 200, 455, "Натиснете ESC за изход" );     
     setlinestyle( SOLID_LINE, 0, 2 );
     setbkcolor( WHITE );
     setcolor( BLACK );  
     line( 40, 420, 40, 60 );
     line( 40, 420, 600, 420 );
     line( 30, 70, 40, 60 );
     line( 50, 70, 40, 60 );
     line( 590, 410, 600, 420 );
     line( 590, 430, 600, 420 );     
     for( i = 400; i > 70; i -= 20 )
         line(30, i, 40, i);
     for( i = 40; i < 600; i += 56 )
         line( i, 420, i, 430 );
     outtextxy( 34, 35, "Y" );
     outtextxy( 610, 408, "X" );
     settextstyle( SANS_SERIF_FONT, HORIZ_DIR, 1 );
     outtextxy( 25, 415, "0");
     for ( i = 4, j = 0; i < 36; i += 4, j += 40 ){
         itoa( i, buffer, 10 );
         outtextxy( 5, 368-j, buffer );
     }     
     /*End Design*/
     
     i = 0;
     j = 0;
     settextstyle( 10, VERT_DIR, 1 );
     while( Head && j < 9) {
          if ( Operation == PRE ) {
             color = 0 + rand() % 14; 
             setfillstyle( SLASH_FILL, color );
             setcolor( color );
          }
          else if ( Operation == SYM ) {
                  color = 0 + rand() % 14;
                  setfillstyle( SOLID_FILL, color );
                  setcolor( color );               
          }
          bar( 41+i, 420-( Head->str.length()*10 ), 96+i, 419 );
          msg = new char[ Head->str.length() ];
          strcpy(msg, Head->str.c_str());
          outtextxy( 58+i, 405-( Head->str.length()*10 ), msg );
          Head = Head->next;
          i += 56;
          j++;  
     }
     
     /*Press ESC to terminate*/
     PressESC:
     while( !kbhit() );
     if ( getch() == ESC )
        closegraph();
     else goto PressESC;     
     /*End terminate*/
}
/*//////////////End Graphics//////////////*/


int main() {
    setlocale( LC_ALL, "bgr_BGR" );//Kирилица
    SetConsoleTitle("Coursework - DSM");
    
    char FileName[26], chGr;
    short int chList, cA = 0, cB = 0, op;
    string buf;
    bool result[1], flag[1];
    flag[0] = true;
    flag[1] = true;
    
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    
    HeadA = NULL;
    HeadB = NULL;
    HeadC = new Item;
    HeadC->next = NULL;
    HeadD = new Item;
    HeadD->next = NULL;
    
    SetConsoleTextAttribute(hConsole, LIGHTCYAN);
    cout << "Въведете елементите на първото множество: \n";
    CreateList( HeadA );
    SetConsoleTextAttribute(hConsole, LIGHTCYAN);
    cout << "\nВъведете елементите на второто множество: \n";
    CreateList( HeadB );
        
    do {
          SetConsoleTextAttribute(hConsole, LIGHTCYAN);                            
          printf( "\n%40sМЕНЮ\n","" );
          printf( "%26s1. Пресечение на две множества\n","" );
          printf( "%26s2. Симетрична разлика\n","" );
          printf( "%26s3. Търсене на елемент\n","" );
          printf( "%26s4. Записване на данните в текстов файл\n","" );
          printf( "%26s5. Извеждане на множество\n","" );
          printf( "%20sПосочете операция или 0 за край: ","" );
          scanf( "%d", &op ); getchar();
           
switch ( op ) {
       
/*//////CASE 1//////*/
case 1:     
    SetConsoleTextAttribute(hConsole, LIGHTRED);
    if ( flag[0] ) {
       Presechenie( HeadA, HeadB );
       flag[0] = false;
    }
       SetConsoleTextAttribute(hConsole, LIGHTGRAY);    
       if ( HeadD->next ) {
          cout << endl <<"Да се изведе ли резултата в текстов режим? ( Y | N ) ";
          cin >> chGr; 
          if ( chGr == 'y' || chGr == 'Y' ) {
             SetConsoleTextAttribute(hConsole, YELLOW);
             PrintList( HeadD->next );
          }
          SetConsoleTextAttribute(hConsole, LIGHTGRAY);
          cout << endl <<"Да се включи ли графичният режим? ( Y | N ) ";
          cin >> chGr;
          if ( chGr == 'y' || chGr == 'Y' )
             GraphicMode( HeadD->next, PRE );      
       }
       else cout << endl <<"Множеството не същестувава!";
break;
/*//////END CASE 1//////*/

/*//////CASE 2//////*/
case 2:
    SetConsoleTextAttribute(hConsole, LIGHTRED);
    if ( flag[1] ) {
       flag[1] = false;         
       Sym( HeadA, HeadB );
    }
       if ( HeadC->next ) {
          SetConsoleTextAttribute(hConsole, LIGHTGRAY);
          cout << endl <<"Да се изведе ли резултата в текстов режим? ( Y | N ) ";
          cin >> chGr; 
          if ( chGr == 'y' || chGr == 'Y' ) {
             SetConsoleTextAttribute(hConsole, YELLOW);
             PrintList( HeadC->next );
          }
          SetConsoleTextAttribute(hConsole, LIGHTGRAY);
          cout << endl <<"Да се включи ли графичният режим? ( Y | N ) ";
          cin >> chGr;
          if ( chGr == 'y' || chGr == 'Y' )
             GraphicMode( HeadC->next, SYM );
       }
       else cout << endl <<"Множеството не същестувава!"; 
break;
/*//////END CASE 2//////*/

/*//////CASE 3//////*/
case 3:
    SetConsoleTextAttribute(hConsole, LIGHTGRAY);
    cout << endl << "Задайте елемента за търсене: ";
    cin >> buf;
    result[0] = SearchItem(buf, HeadA);
    result[1] = SearchItem(buf, HeadB);
    SetConsoleTextAttribute(hConsole, LIGHTRED);
    if ( result[0] && result[1] )
       cout << endl << "Елементът се съдържа и в двете множества.";
    else if ( result[0] )
       cout << endl << "Елементът се съдържа в първото множество.";
    else if ( result[1] )
       cout << endl << "Елементът се съдържа във второто множество.";
    else
       cout << endl << "Елементът не е намерен.";
break;
/*//////END CASE 3//////*/

/*//////CASE 4//////*/
case 4:
    ToTxt( HeadA );
    ToTxt( HeadB );
    SetConsoleTextAttribute(hConsole, LIGHTRED);
    cout << "\nДанните са записани в \"Output.txt\"..";
    getchar();     
break;
/*//////END CASE 4//////*/

/*//////CASE 5//////*/
case 5:
    SetConsoleTextAttribute(hConsole, LIGHTGRAY);
    again2:
    cout << "\nИзберете множество: ";
    cout << "\n\t1. Първото множество;";
    cout << "\n\t2. Второто множество;";
    if ( HeadC->next )
       cout << "\n\t3. Множеството получено при операцията,"
            << "\n\t   симетрична разлика.";
    if ( HeadD->next )
       cout << "\n\t4. Множеството получено при операцията,"
            << "\n\t   пресечение на две множества.";
    cout << endl;
    cin >> chList;
    if ( chList == 1 ) {
       SetConsoleTextAttribute(hConsole, YELLOW);
       PrintList( HeadA );
    }
    else if ( chList == 2 ) {
       SetConsoleTextAttribute(hConsole, LIGHTMAGENTA);                   
       PrintList( HeadB );
    }
    else if ( HeadC->next && chList == 3 ) {
       SetConsoleTextAttribute(hConsole, LIGHTGREEN);
       PrintList( HeadC->next );
    }
    else if ( HeadD->next && chList == 4 ) {
       SetConsoleTextAttribute(hConsole, WHITE);
       PrintList( HeadD->next );
    }    
    else {
       SetConsoleTextAttribute(hConsole, LIGHTGRAY);
       cout << endl << "Неправилен избор!" << endl; 
       goto again2;
    }  
break;
/*//////END CASE 5//////*/

}//switch
    } while ( op != 0 );
 
    cout << endl;
    cout << "\nНатиснете произволен клавиш за край..";
    getchar();
	return( 0 );
}
