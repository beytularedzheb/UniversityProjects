unit Unit3;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls;

type
TIndex = Record
  index : integer;
  position : integer;
end;

IndFile = File of TIndex;

TStudent = Record
  fac_num: string[6];
  first_name: string[25];
  sec_name: string[25];
  last_name: string[25];
  group: integer;
  sr_usp: real;
  date_r: TDate;
  date_z: TDate;
  deleted: boolean;
end;

InfFile = File of TStudent;


var
indF: IndFile;
infF: InfFile;
student: TStudent;
index: TIndex;
positionFound: integer;

{\\ Podadeni Komandi}
  tyrs:string;
  dob:string;
  red:string;
  iztr:string;
  vyzst:string;
  syzd:string;
  otv:string;
  izhod:string;
  izch:string;
  zatv:string;
{// Podadeni Komandi}

procedure SortIndexFile();
function Search(keyword: integer): integer;

implementation
procedure SortIndexFile();
var
  M,J,H : Integer;
  Buffer : TIndex;
  IndexArray : array[1..100] of TIndex;
begin
  Reset(IndF);

  for J := 1 to FileSize(IndF) do
    Read(IndF,IndexArray[J]);

  H := FileSize(IndF) Div 2;
  while H > 0 do begin
    M := H + 1;
    repeat
      J := M - H;
      while J > 0 do begin
        if IndexArray[J].index <= IndexArray[J+H].index then
          J := 0
        else begin
          Buffer := IndexArray[J];
          IndexArray[J] := IndexArray[J + H];
          IndexArray[J + H] := Buffer;
        end;
        J := J - H;
      end;

     M := M + 1;
    until M > FileSize(IndF);
    H := H div 2;
  end;

  Seek(IndF, 0);
  for J := 1 to FileSize(IndF) do
    Write(IndF,IndexArray[J]);
  CloseFile(IndF);
end;

function Search(keyword: integer): integer;
var
  I,L,D:Integer;
begin
  Reset(indF);
  if FileSize(indF) = 0 then begin
    Result := -1;
    exit;
  end;

  {cycles := 0;}
  L := 0; D := FileSize(indF)-1;
  repeat
    {cycles := cycles + 1; }
    I := (L + D) div 2;
    Seek(indF, I);
    Read(indF, Index);
    if keyword > Index.index then
      L := I + 1
    else if keyword < Index.index then
      D := I - 1;
  until (keyword = Index.index) or (L > D);

  if (keyword = Index.index) then
    Result := Index.position-1
  else
    Result := -1;
end;

end.
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           