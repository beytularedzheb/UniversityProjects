unit GenerateObjectCode;

interface

uses Dialogs, SysUtils, SyntacticAnalysis, SemanticAnalysis;

var
  step: integer;
  fileHandler: TextFile;
  isCreatedASM: boolean = false;
  
  function GenObjCode: integer;
  procedure GenASMCode;
  procedure SaveToASMFile(txtCode: string);

implementation

procedure SaveToASMFile(txtCode: string);
begin
  AssignFile(fileHandler, 'GeneratedASM.asm');
  if (isCreatedASM) then begin
    Append(fileHandler);
    Write(fileHandler, txtCode);
  end
  else begin
    Rewrite(fileHandler);
    isCreatedASM := true;
    Write(fileHandler, txtCode);
  end;
  CloseFile(fileHandler);
end;

procedure GenASMCode;
var
  i: integer;
  ifHaveLbl: string;
  sysLlb: integer;
begin
  sysLlb := 1;
  i := 1;
  while (i < TetN) do begin
    if (Tetr[i].Etiket <> '') then
      ifHaveLbl := Tetr[i].Etiket + ': ';
    if (Tetr[i].KO = '+') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('ADD ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('STA ' + SymbolsArr[Tetr[i].Result].Symb + #10);
    end
    else if (Tetr[i].KO = '-') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('SUB ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('STA ' + SymbolsArr[Tetr[i].Result].Symb + #10);
    end
    else if (Tetr[i].KO = '*') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('MUL ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('STA ' + SymbolsArr[Tetr[i].Result].Symb + #10);
    end
    else if (Tetr[i].KO = '/') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('DIV ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('STA ' + SymbolsArr[Tetr[i].Result].Symb + #10);
    end
    else if (Tetr[i].KO = '=') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('STA ' + SymbolsArr[Tetr[i].Result].Symb + #10);
    end
    else if (Tetr[i].KO = '<') or (Tetr[i].KO = '>') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('SUB ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('BRP ' + 'LB' + IntToStr(sysLlb) + #10);
      Inc(sysLlb);
      if (Tetr[i].KO = '<') then
        SaveToASMFile('LDA 1' + #10)
      else
        SaveToASMFile('LDA 0' + #10);
      SaveToASMFile('JMP ' + 'LB' + IntToStr(sysLlb) + #10);
      if (Tetr[i].KO = '<') then
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 0' + #10)
      else
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 1' + #10);
      SaveToASMFile('LB' + IntToStr(sysLlb) + ': STA ' +
                    SymbolsArr[Tetr[i].Result].Symb + #10);
      Inc(sysLlb);
    end
    else if (Tetr[i].KO = '==') or (Tetr[i].KO = '!=') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('SUB ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('BRZ ' + 'LB' + IntToStr(sysLlb) + #10);
      Inc(sysLlb);
      if (Tetr[i].KO = '==') then
        SaveToASMFile('LDA 1' + #10)
      else
        SaveToASMFile('LDA 0' + #10);
      SaveToASMFile('JMP ' + 'LB' + IntToStr(sysLlb) + #10);
      if (Tetr[i].KO = '==') then
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 0' + #10)
      else
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 1' + #10);
      SaveToASMFile('LB' + IntToStr(sysLlb) + ': STA ' +
                    SymbolsArr[Tetr[i].Result].Symb + #10);
      Inc(sysLlb);
    end
    else if (Tetr[i].KO = '=<') or (Tetr[i].KO = '=>') then begin
      SaveToASMFile(ifHaveLbl + 'LDA ' + SymbolsArr[Tetr[i].Op1].Symb + #10);
      SaveToASMFile('SUB ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile('BRZP ' + 'LB' + IntToStr(sysLlb) + #10);
      Inc(sysLlb);
      if (Tetr[i].KO = '=<') then
        SaveToASMFile('LDA 1' + #10)
      else
        SaveToASMFile('LDA 0' + #10);
      SaveToASMFile('JMP ' + 'LB' + IntToStr(sysLlb) + #10);
      if (Tetr[i].KO = '=<') then
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 0' + #10)
      else
        SaveToASMFile('LB' + IntToStr(sysLlb-1) + ': LDA 1' + #10);
      SaveToASMFile('LB' + IntToStr(sysLlb) + ': STA ' +
                    SymbolsArr[Tetr[i].Result].Symb + #10);
      Inc(sysLlb);
    end
    else if (Tetr[i].KO = 'JMP') then begin
      SaveToASMFile(ifHaveLbl + 'JMP ' + Tetr[Tetr[i].Op1].Etiket + #10)
    end
    else if (Tetr[i].KO = 'BRZ')
    then begin
      SaveToASMFile('LDA ' + SymbolsArr[Tetr[i].Op2].Symb + #10);
      SaveToASMFile(Tetr[i].KO + ' ' + Tetr[Tetr[i].Op1].Etiket + #10);
    end
    else if (Tetr[i].KO = 'STOP') then begin
      SaveToASMFile(ifHaveLbl + 'BRK' + #10);
    end;
    Inc(i);
    ifHaveLbl := '';
  end;
end;

function GenObjCode: integer;
begin
  if (step < TetN) then begin
    if (Tetr[step].KO = '+') then begin
      SymbolsArr[Tetr[step].Result].Value := SymbolsArr[Tetr[step].Op1].Value +
                                          SymbolsArr[Tetr[step].Op2].Value;
    end
    else if (Tetr[step].KO = '-') then begin
      SymbolsArr[Tetr[step].Result].Value := SymbolsArr[Tetr[step].Op1].Value -
                                          SymbolsArr[Tetr[step].Op2].Value;
    end
    else if (Tetr[step].KO = '*') then begin
      SymbolsArr[Tetr[step].Result].Value := SymbolsArr[Tetr[step].Op1].Value *
                                          SymbolsArr[Tetr[step].Op2].Value;
    end
    else if (Tetr[step].KO = '/') then begin
      if (SymbolsArr[Tetr[step].Op2].Value = 0) then begin
        ShowMessage('На нула не се дели! Това е стойността на: ' +
                    SymbolsArr[Tetr[step].Op2].Symb);
        exit;
      end
      else begin
        SymbolsArr[Tetr[step].Result].Value :=SymbolsArr[Tetr[step].Op1].Value /
                                              SymbolsArr[Tetr[step].Op2].Value;
      end
    end
    else if (Tetr[step].KO = '=') then begin
      SymbolsArr[Tetr[step].Result].Value := SymbolsArr[Tetr[step].Op1].Value;
    end
    else if (Tetr[step].KO = '>') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value > SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = '<') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value < SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = '==') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value = SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = '!=') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value <> SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = '=<') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value <= SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = '=>') then begin
      SymbolsArr[Tetr[step].Result].Value := 0;
      if (SymbolsArr[Tetr[step].Op1].Value >= SymbolsArr[Tetr[step].Op2].Value)
      then
        SymbolsArr[Tetr[step].Result].Value := 1;
    end
    else if (Tetr[step].KO = 'BRZ')
    then begin
      if (SymbolsArr[Tetr[step].Op2].Value = 0) then begin
        step := Tetr[step].Op1;
        Dec(step);
      end;
    end
    else if (Tetr[step].KO = 'JMP') then begin
      step := Tetr[step].Op1;
      Dec(step);
    end
    else if (Tetr[step].KO = 'STOP') then
      step := TetN - 1;
    Inc(step);
    GenObjCode := step;
  end;
end;


end.
