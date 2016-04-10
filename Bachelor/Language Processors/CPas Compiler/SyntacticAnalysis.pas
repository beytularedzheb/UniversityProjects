unit SyntacticAnalysis;

interface

uses Dialogs, SysUtils;

type
  TSymbols = record
    Symb: string;
    Code: integer;
    Value: real;
  end;
  SymbolsArray = array[1..300] of TSymbols;
  PointArr = array[1..300] of integer;

var
  SymbolsArr: SymbolsArray;
  PointListArr: PointArr;
  S: SymbolsArray;
  P: PointArr;
  Sz: integer;
  IND: integer;
  msg: string;
  skobi: integer;
  chOp: boolean;

  indexList: integer;
  N: integer = 300;

  function Hash(Symb: string): integer;
  procedure AddToList(Point: integer);
  function FindTab(Symb: string; Code: integer; Value: real): integer;

  procedure Init;
  procedure Expression;
  procedure Condition;
  procedure OperatorIF;
  procedure OperatorWhile;
  function SyntAnal(SArr: SymbolsArray; PtrArr: PointArr; Size: integer):string;

implementation

function Hash(Symb: string): integer;
var
  L: integer;
begin
  L := Length(Symb);
  Hash := ((ord(Symb[1]) + ord(Symb[L])) * L) mod N + 1;
end;

function FindTab(Symb: string; Code: integer; Value: real): integer;
var
  h, p, i: integer;
begin
  h := Hash(Symb);
  for p := 0 to N-1 do begin
    i := (h + p) mod N + 1;
    if SymbolsArr[i].Symb = '' then begin
      SymbolsArr[i].Symb := Symb;
      SymbolsArr[i].Code := Code;
      SymbolsArr[i].Value := Value;
      FindTab := i;
      exit;
    end
    else if SymbolsArr[i].Symb = Symb then begin
      FindTab := i;
      exit;
    end;
  end;
end;

procedure AddToList(Point: integer);
begin
  if (indexList < 300) then begin
    PointListArr[indexList] := Point;
    Inc(indexList);
  end
  else ShowMessage('Списъкът "PointListArr" е запълнен!');
end;

procedure OperatorIF;
begin
  if (IND <= Sz-2) then begin
    if (S[P[IND]].Code = 39) then begin
     Inc(IND);
     if (S[P[IND]].Code = 24) then begin
      Inc(IND);
      Init;
      if (S[P[IND]].Code = 25) then begin
        Inc(IND);
        if (S[P[IND]].Code = 26) then begin
          Inc(IND);
          Init;
          exit;
        end
        else if (S[P[IND]].Code = 40) then begin
          Inc(IND);
          if (S[P[IND]].Code = 24) then begin
            Inc(IND);
            Init;
            if (S[P[IND]].Code = 25) then begin
              Inc(IND);
              if (S[P[IND]].Code = 26) then begin
                Inc(IND);
                Init;
                exit;
              end
              else begin
                msg := '[ELSE] Очаква се ; след }';
                exit;
              end;
            end
            else begin
              if (msg = '') then msg := '[ELSE] Очаква се } или има грешен изр'
                + 'аз, открит е следният оператор/символ: ' + S[P[IND]].Symb;
              exit;
            end;
          end
          else begin
            msg := '[ELSE] Очаква се { след ELSE';
            exit;
          end;
        end
        else begin
          msg := '[IF] Очаква се ; или ELSE след }';
          exit;
        end;
      end
      else begin
        msg := '[IF] Очаква се }';
        exit;
      end;
     end
     else begin
      msg := '[IF] Очаква се { след THEN';
      exit;
     end;
    end
    else begin
      msg := '[IF] Грешен оператор, очаква се THEN..';
      exit;
    end;
  end
  else begin
    if (msg = '') then msg := '[IF] Грешен/недовършен оператор';
    exit;
  end;
end;

procedure OperatorWhile;
begin
  if (IND <= Sz-2) then begin
    if (S[P[IND]].Code = 45) then begin
     Inc(IND);
     if (S[P[IND]].Code = 24) then begin
      Inc(IND);
      Init;
      if (S[P[IND]].Code = 25) then begin
        Inc(IND);
        if (S[P[IND]].Code = 26) then begin
          Inc(IND);
          Init;
          exit;
        end
        else begin
          msg := '[WHILE] Очаква се ; след }';
          exit;
        end;
      end
      else begin
        msg := '[WHILE] Очаква се }';
        exit;
      end;
     end
     else begin
      msg := '[WHILE] Очаква се { след DO';
      exit;
     end;
    end
    else begin
      msg := '[WHILE] Грешен оператор, очаква се DO..';
      exit;
    end;
  end
  else begin
    if (msg = '') then msg := '[WHILE] Грешен/недовършен оператор';
    exit;
  end;
end;

procedure Condition;
begin
  if (IND <= Sz-2) then begin
    case S[P[IND]].Code of
{////}27 : begin                                                          { ( }
        Inc(IND);
        Inc(skobi);
        if (S[P[IND]].Code = 111) or
           (S[P[IND]].Code = 222) then
           Condition
        else begin
          msg := 'Очаква се ID или константа след ' + S[P[IND-1]].Symb +
                 ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end;
      end;
{////}28 : begin                                                        { ) }
        Inc(IND);
        Dec(skobi);
        case S[P[IND]].Code of
          13 : Condition;
          14 : Condition;
          39 : OperatorIF;
          45 : OperatorWhile;
          else begin
            msg := 'Очаква се THEN, DO, $$ или || след ' + S[P[IND-1]].Symb +
                   ', но е намерен: ' + S[P[IND]].Symb;
            exit;
          end;
        end;
      end;
{////}else begin                                                  { ID | Const}
        if (S[P[IND]].Code = 111) or (S[P[IND]].Code = 222) then begin
          Inc(IND);
          case S[P[IND]].Code of
            18 : Condition;
            19 : Condition;
            20 : Condition;
            21 : Condition;
            22 : Condition;
            23 : Condition;
            28 : Condition;
            else begin
              msg := 'Очаква се ) или знак за сравнение след ' +
                      S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
              exit;
            end;
          end;
        end
        else if (S[P[IND]].Code = 18) or                                  { > }
                (S[P[IND]].Code = 19) or                                  { < }
                (S[P[IND]].Code = 20) or                                 { == }
                (S[P[IND]].Code = 21) or                                 { <= }
                (S[P[IND]].Code = 22) or                                 { >= }
                (S[P[IND]].Code = 23) then begin                         { != }
          Inc(IND);
          if (S[P[IND]].Code = 111) or
             (S[P[IND]].Code = 222) then
            Condition
          else begin
            msg := 'Очаква се ID или константа след ' + S[P[IND-1]].Symb +
                 ', но е намерен: ' + S[P[IND]].Symb;
            exit;
          end;
        end
        else if (S[P[IND]].Code = 13) or (S[P[IND]].Code = 14) then begin
          Inc(IND);
          if (S[P[IND]].Code = 27) then
            Condition
          else begin
            msg := 'Очаква се ( след ' + S[P[IND-1]].Symb + ', но е намерен: ' +
                    S[P[IND]].Symb;
            exit;
          end;
        end
        else begin
          exit;
        end;
      end;
    end;
  end
  else begin
    if (msg = '') then msg := 'Грешен/недовършен израз/тяло на оператор..';
    exit;
  end;
end;


procedure Expression;
begin
  if (IND <= Sz-2) then begin
    case S[P[IND]].Code of
{////}27 : begin                                                          { ( }
        Inc(IND);
        Inc(skobi);
        if (S[P[IND]].Code <> 111) and
           (S[P[IND]].Code <> 222) and
           (S[P[IND]].Code <> 27) then begin
          msg := '[Expression] Очаква се ID, константа или ( след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}111 : begin                                                        { ID }
        Inc(IND);
        if ((S[P[IND]].Code < 6) or
           (S[P[IND]].Code > 9)) and
           ((S[P[IND]].Code <> 26) and
           (S[P[IND]].Code <> 28)) then begin
          msg := '[Expression] Очаква се +, -, *, /, .,  ; или ) след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;                                                            { const }
{////}222 : begin
        Inc(IND);
        if ((S[P[IND]].Code < 6) or
           (S[P[IND]].Code > 9)) and
           ((S[P[IND]].Code <> 26) and
           (S[P[IND]].Code <> 28)) then begin
          msg := '[Expression] Очаква се +, -, *, /, ., ; или ) след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}6 : begin                                                           { + }
        Inc(IND);
        if (S[P[IND]].Code <> 111) and
           (S[P[IND]].Code <> 222) and
           (S[P[IND]].Code <> 27) then begin
          msg := '[Expression] Очаква се ID, константа или ( след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}7 : begin                                                           { - }
        Inc(IND);
        if (S[P[IND]].Code <> 111) and
           (S[P[IND]].Code <> 222) and
           (S[P[IND]].Code <> 27) then begin
          msg := '[Expression] Очаква се ID, константа или ( след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}8 : begin                                                           { * }
        Inc(IND);
        if (S[P[IND]].Code <> 111) and
           (S[P[IND]].Code <> 222) and
           (S[P[IND]].Code <> 27) then begin
          msg := '[Expression] Очаква се ID, константа или ( след ' +
                  S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}9 : begin                                                           { / }
        Inc(IND);
        if (S[P[IND]].Code <> 111) and
           (S[P[IND]].Code <> 222) and
           (S[P[IND]].Code <> 27) then begin
          msg := '[Expression] Очаква се ID, константа или ( след ' +
                 S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}26 : begin                                                          { ; }
        Inc(IND);
        exit;
      end;
{////}28 : begin                                                          { ) }
        Inc(IND);
        Dec(skobi);
        if (S[P[IND]].Code < 6) or
           ((S[P[IND]].Code > 9) and
           (S[P[IND]].Code <> 26) and
           (S[P[IND]].Code <> 28))then begin
          msg := '[Expression] Очаква се +, -, *, /, ., ; или ) след ' +
                 S[P[IND-1]].Symb + ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end
        else
          Expression;
      end;
{////}else begin
        if (msg = '') then  msg := '[Expression] Грешен символ: ' +
                                    S[P[IND]].Symb;
        exit;
      end;
    end;
  end
  else begin
    exit;
  end;
end;


procedure Init;
var
  Prom: string;
begin
  if (IND <= Sz-2) then begin
    case S[P[IND]].Code of
{////}111 : begin
        Inc(IND);
        if (S[P[IND]].Code = 17) then begin
          Inc(IND);
          if (S[P[IND]].Code = 111) or
             (S[P[IND]].Code = 222) or
             (S[P[IND]].Code = 27) then begin
            Expression;
            Init;
          end
          else begin
            msg := '[Expression] Очаква се ID, константа или ( след =, но е ' +
                   'намерен: ' + S[P[IND]].Symb;
            exit;
          end;
        end
        else begin
          msg := '[Expression] Очаква се = след ' + S[P[IND-1]].Symb +
                 ', но е намерен: ' + S[P[IND]].Symb;
          exit;
        end;
      end;
{////}222 : begin
         if (msg = '') then
          msg := '[Expression] На константа не може да се присвоява стойност!';
         exit;
      end;
{////}38 : begin
        Inc(IND);
        Condition;
        if (msg = '') then Init;
      end;
{////}37 : begin
        Inc(IND);
        Condition;
        if (msg = '') then Init;
      end;
{////}else begin
        exit;
      end;
    end;
  end
  else begin
    exit;
  end;
end;

function SyntAnal(SArr: SymbolsArray; PtrArr: PointArr; Size: integer):string;
begin
  chOp := true;
  skobi := 0;
  msg := '';
  IND := 1;
  S := SArr;
  P := PtrArr;
  Sz := Size;

  if (Sz > IND) then begin
    if (S[P[IND]].Code = 111) then begin
      Inc(IND);
      if (Sz > IND) and (S[P[IND]].Code = 24) then begin
        Inc(IND);
        Init;
        if (msg = '') and (skobi <> 0) then
          msg := 'Броят на отварящите ( и затварящите ) скоби трябва да е еднакъв';
        if (msg <> '') then begin
          SyntAnal := msg;
          exit;
        end;
        if (S[P[IND]].Code = 26) then Dec(IND);
        if (msg = '') and (S[P[IND]].Code = 25) then begin
          if (Sz > IND) then begin
            Inc(IND);
            if (IND < Sz) and (S[P[IND]].Symb <> '') then
              SyntAnal := 'Не може да има символ/и след затварящата скоба } на void'
            else
              SyntAnal := '';
          end else SyntAnal := 'Очаква се } за void';
        end
        else if (msg = '') and (S[P[Sz]].Code <> 25) then begin
          SyntAnal := 'Очаква се } за void';
          exit;
        end;
      end
      else SyntAnal := 'Очаква се { след името на програмата.';
    end
    else
      SyntAnal := 'Пропуснали сте името на програмата, намерен е:  ' +
                  S[P[IND]].Symb + #13 + 'Пример: "void MyProgram {...}"';
  end
  else begin
    SyntAnal := 'Очаква се името на програмата.'+ #13 +
                'Пример: "void MyProgram {...}"';
    exit;
  end;
end;

end.
