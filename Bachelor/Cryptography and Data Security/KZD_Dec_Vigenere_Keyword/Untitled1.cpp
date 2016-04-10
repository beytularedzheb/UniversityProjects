#include <iostream>
#include <string.h>
using namespace std;

char *abc = {"ABCDEFGHIJKLMNOPQRSTUVWXYZ"};
char abc2[26];

void rewVijener(char *str, char vijKey[26]) {
     char ch;
	 int i, j, len = strlen(str);
	 string rez;
	 char rez1[512];
     
     rez = "";
	 int vk = strlen(vijKey);
     for (i = 0; i < vk; i++) {
         if (islower(vijKey[i]))
            vijKey[i] = toupper(vijKey[i]);
	 }
     int buf[512];
     for (i = 0; i < len; i++) {
	  if (isalpha(str[i])) {
             ch = str[i];
             if (islower(str[i]))
                ch = toupper(str[i]);
             for (j = 0; j < 26; j++)
                 if (ch == abc[j]){
                    buf[i] = j;                          
                    break;
                 }                                                             
         }
         else continue;   
     }
	 
     int keyBuf[40];
     int ss;
     
     for (i = 0; i < vk; i++) { 
         for (j = 0; j < 26; j++)
             if (vijKey[i] == abc[j])
                keyBuf[i] = j;  
	 }
     for (i = 0, j = 0; i < len; i++, j++) {
         if (j == vk)
            j = 0;
         ss = (buf[i] - keyBuf[j]) % 26;
         
         while (ss<0)
               ss += 26; 
         rez += abc[ss];
     }

	 cout << rez << " ";
}

void keywordDec() {
     int i, j;
     char curCh, text[40];
     string pt1 = "";
     
     cin.sync();
     cout << "\nZadaite teksta: ";
     gets(text);
     
     char vKey[256];
     cout << "\nZadaite klyucha pri shifura na Vijener: ";
     cin >> vKey;
          
	 for (i = 0; i < strlen(text); i++) {
		 for (j = 0; j < 26; j++){              
			if (isalpha(text[i]) && toupper(text[i]) == abc2[j]) {
			   pt1 += abc[j];
			   break;
			}                         
		 }
	 } 
	 if (pt1 != "") {
		char buf[256];
		strcpy(buf, pt1.c_str());
		rewVijener(buf, vKey);
	}		           
}

void crtAbcSub() {
     char *pch, keySub[40];
     int k = 0, l, i, j;
     
     cout << "Zadaite klyucha pri shifura s klyuchova duma: ";
     cin >> keySub;
     for (i = 0; i < strlen(keySub); i++)
         if (islower(keySub[i]))
            keySub[i] = toupper(keySub[i]);
         else continue;
     for (i = 0; i < strlen(keySub); i++) {
         pch = strchr(abc2, keySub[i]);
         if (!pch) { 
            abc2[k] = keySub[i];            
            k++;
         } 
         else continue; 
     }
     
     l = strlen(abc2);
     
     for (i = 0; i < 26; i++) 
         for (j = 0; j < l; j++) {
         pch = strchr(abc2, abc[i]);
         if (!pch) {
            abc2[k] = abc[i];
            k++;
         } 
         else continue; 
     }        
}

int main() {   
    crtAbcSub();
    keywordDec();
    
    return 0;
}
