unit SemanticAnalysis;

interface

uses Dialogs, SysUtils, SyntacticAnalysis;

type
  TTetrada = record
    KO: string;
    Etiket: string;
    Op1: integer;
    Op2: integer;
    Result: integer;
    Flag: boolean;
    JumpUp: integer;
    JumpDown: integer;
  end;

  Tetrada = array[1..300] of TTetrada;
  
var
  Res: integer;
  R: integer;

  Tetr: Tetrada;
  TetN: integer;
  sysVarN: integer;

  jmpUp: integer;
  lblCounter: integer;

  procedure SemAnal(SArr: SymbolsArray; PtrArr: PointArr; Size: integer);
  procedure Z;
  procedure Izraz(var Op1: integer);
  procedure Term (var Op1: integer);
  procedure Faktor(var Op: integer);
  procedure ResetVars(SArr: SymbolsArray; PtrArr: PointArr; Size: integer);
  procedure NovaTetrada(KO: string; Op1, Op2, Result: integer; flag: boolean);
  function SysVar: integer;
  procedure OpredeliBRiJMP(WHLorIForELSE: integer);
  procedure ClearTetrTable;

implementation

procedure ClearTetrTable;
var
  i: integer;
begin
  for i := 1 to TetN-1 do begin
    Tetr[i].KO := '';
  end;
end;

procedure OpredeliBRiJMP(WHLorIForELSE: integer);
var
  brSim: integer;
  brTetr: integer;
  brOp: integer;
begin
  brSim := 0;
  brTetr := 0;
  brOp := 0;
  
  while (IND < Sz) do begin
    while (S[P[IND]].Code <> 38) and (S[P[IND]].Code <> 37) and
          (S[P[IND]].Code <> 25) and (S[P[IND]].Code <> 40) and
          (S[P[IND]].Code <> 6) and (S[P[IND]].Code <> 7) and
          (S[P[IND]].Code <> 8) and (S[P[IND]].Code <> 9) and
          (S[P[IND]].Code <> 17) and (S[P[IND]].Code <> 24)
    do begin
      Inc(IND);
      Inc(brSim);
    end;
    if (S[P[IND]].Code = 38) or (S[P[IND]].Code = 37) or
       (S[P[IND]].Code = 6) or  (S[P[IND]].Code = 40) or
       (S[P[IND]].Code = 7) or (S[P[IND]].Code = 8) or
       (S[P[IND]].Code = 9) or (S[P[IND]].Code = 17)
    then begin
      if (S[P[IND]].Code = 38) then  brTetr := brTetr + 2
      else if (S[P[IND]].Code = 37) then brTetr := brTetr + 3
      else Inc(brTetr);
    end
    else if (S[P[IND]].Code = 25) then
      Dec(brOp)
    else if (S[P[IND]].Code = 24) then
      Inc(brOp);
    Inc(IND);
    Inc(brSim);
    if (brOp = 0) then break;
  end;

  if (brOp = 0) then begin
      if (WHLorIForELSE = 37) or ((WHLorIForELSE = 38) and
         (S[P[IND]].Code = 40))
      then
        Tetr[TetN-1].Op1 := TetN + brTetr + 1 // BR
      else
        Tetr[TetN-1].Op1 := TetN + brTetr;

      if (WHLorIForELSE = 37) then begin
        Inc(lblCounter);
        Tetr[TetN + brTetr].KO := 'JMP';
        Tetr[TetN + brTetr].Op1 := jmpUp;
        Tetr[TetN + brTetr].Op2 := -1;
        Tetr[TetN + brTetr + 1].Etiket := 'ET' + IntToStr(lblCounter);
        Tetr[TetN + brTetr].Result := -1;
        Tetr[TetN + brTetr].Flag := false;
      end;
  end;
  IND := IND - brSim;
end;

procedure NovaTetrada(KO: string; Op1, Op2, Result: integer; flag: boolean);
begin
  if (Tetr[TetN].KO = 'JMP') then begin
    Inc(TetN);
    NovaTetrada(KO, Op1, Op2, Result, flag);
    exit;
  end;
  if (Tetr[TetN].KO = '') then begin
    Tetr[TetN].KO := KO;
    Tetr[TetN].Op1 := Op1;
    Tetr[TetN].Op2 := Op2;
    Tetr[TetN].Result := Result;
    Tetr[TetN].Flag := flag;
    Inc(TetN);
  end;
end;

function SysVar: integer;
begin
  SysVar := FindTab('@_' + IntToStr(sysVarN), 111, 0);
  Inc(sysVarN);
end;

procedure ResetVars;
begin
  S := SArr;
  P := PtrArr;
  Sz := Size;
  IND := 1;
  
  ClearTetrTable;
  TetN := 1;
  sysVarN := 1;
  lblCounter := 0;
end;

procedure SemAnal(SArr: SymbolsArray; PtrArr: PointArr; Size: integer);
var
  cOp1, cOp2: integer;
  cOper: string;
begin
  ResetVars(SArr, PtrArr, Size);

  while (IND < Sz) do begin
    while (S[P[IND]].Code <> 17) and (S[P[IND]].Code <> 37) and
            (S[P[IND]].Code <> 38) and (S[P[IND]].Code <> 40) and (IND < Sz)
    do begin
      Inc(IND);
    end;
    if (S[P[IND]].Code = 40) then begin
      NovaTetrada('JMP', TetN - 1, -1, -1, false);
      Inc(IND);
      OpredeliBRiJMP(40);
    end
    else if (S[P[IND]].Code = 17) then begin
      Dec(IND);
      if (IND < Sz) then
        Z;
    end
    else if (S[P[IND]].Code = 37) or (S[P[IND]].Code = 38) then begin
      IND := IND + 2;
      cOp1 := P[IND];
      Inc(IND);
      cOper := S[P[IND]].Symb;
      Inc(IND);
      cOp2 := P[IND];
      R := SysVar;
      AddToList(R);
      NovaTetrada(cOper, cOp1, cOp2, R, true);
      
      Inc(lblCounter);

      NovaTetrada('BRZ', TetN - 1, R, -1, false);
      jmpUp := TetN - 2;
      Tetr[jmpUp].Etiket := 'ET' + IntToStr(lblCounter);
      if (S[P[IND - 4]].Code = 37) then OpredeliBRiJMP(37)
      else if (S[P[IND - 4]].Code = 38) then OpredeliBRiJMP(38);
    end;
  end;
end;

procedure Z;
var
  Prom: integer;
begin
  Prom := P[IND];
  Inc(IND);
  if (IND < Sz) then begin
    if (S[P[IND]].Code <> 17) then begin
      ShowMessage('Error =');
      exit;
    end;

    Inc(IND);
    Izraz(Res);
    NovaTetrada('=', Res, -1, Prom, true);
  end;
end;

procedure Izraz(var Op1: integer);
var
  Op2: integer;
  Operaciq: string;
begin
  Term(Op1);
  if (IND < Sz) then begin
    while (S[P[IND]].Code = 6) or (S[P[IND]].Code = 7) do begin
      Operaciq := S[P[IND]].Symb;
      Inc(IND);
      Term(Op2);
      R := SysVar;
      AddToList(R);
      if (Operaciq = '+') then
        NovaTetrada('+', Op1, Op2, R, true)
      else if (Operaciq = '-') then
        NovaTetrada('-', Op1, Op2, R, true);
      Op1 := R;
    end;
  end;
end;

procedure Term (var Op1 : integer);
var
  Op2: integer;
  Operaciq: string;
begin
  Faktor(Op1);
  if (IND < Sz) then begin
    while (S[P[IND]].Code = 8) or (S[P[IND]].Code = 9) do begin
      Operaciq := S[P[IND]].Symb;
      Inc(IND);
      Faktor(Op2);
      R := SysVar;
      AddToList(R);
      if (Operaciq = '*') then
        NovaTetrada('*', Op1, Op2, R, true)
      else if (Operaciq = '/') then
        NovaTetrada('/', Op1, Op2, R, true);
      Op1 := R;
    end;
  end;
end;

procedure Faktor(var Op: integer);
begin
  if (IND < Sz) then begin
    if (S[P[IND]].Code = 27) then begin
      Inc(IND);
      Izraz(Op);
      if (S[P[IND]].Code <> 28) then begin
        ShowMessage('")" expected !');
        exit;
      end;
      Inc(IND);
    end
    else begin
      Op := P[IND];
      Inc(IND);
    end;
  end;
end;

end.
