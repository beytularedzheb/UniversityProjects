unit Unit3;

interface

uses Classes, SysUtils;

type
  TDiplomnaRabota = record
    por_nom: string[5];
    tema_ime: string[80];
    ezik_za_progr: string[30];
    tip_pril: string[35];
    rukovoditel: string[50];
    student: string[50];
    fac_nom: string[6];
    zaet: integer;
  end;
  
  InfFile = File of TDiplomnaRabota;

var
  infF: InfFile;
  fileName: string;

  tyrsene: char;
  redaktirane: char;
  syzd_fail: char;
  otvarqne: char;
  dobavqne: char;
  iztrivane: char;
  
implementation
end.
 