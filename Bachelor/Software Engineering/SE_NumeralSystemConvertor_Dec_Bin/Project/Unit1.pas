unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, StdCtrls;

type
  TForm1 = class(TForm)
    MainMenu1: TMainMenu;
    PopupMenu1: TPopupMenu;
    N1: TMenuItem;
    Edit1: TMenuItem;
    About1: TMenuItem;
    Clear1: TMenuItem;
    Cut1: TMenuItem;
    Copy1: TMenuItem;
    Paste1: TMenuItem;
    N2: TMenuItem;
    Exit1: TMenuItem;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;
    Label3: TLabel;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    Cut2: TMenuItem;
    Copy2: TMenuItem;
    Paste2: TMenuItem;
    N4: TMenuItem;
    Clear2: TMenuItem;
    Button2: TButton;
    Edit2: TEdit;
    Memo2: TMemo;
    About2: TMenuItem;
    procedure Button1Click(Sender: TObject);
    procedure Edit2KeyPress(Sender: TObject; var Key: Char);
    procedure FormCreate(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Exit1Click(Sender: TObject);
    procedure About2Click(Sender: TObject);
    procedure Cut1Click(Sender: TObject);
    procedure Paste1Click(Sender: TObject);
    procedure Copy1Click(Sender: TObject);
    procedure Clear1Click(Sender: TObject);
    procedure Cut2Click(Sender: TObject);
    procedure Copy2Click(Sender: TObject);
    procedure Paste2Click(Sender: TObject);
    procedure Clear2Click(Sender: TObject);
    procedure Memo2KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  resultFile: TextFile;
  function BinToInt(Value: String): Int64;
implementation

uses Unit2;

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
  cqlaChast, bufCqlaChast: Int64;
  drobnaChast: Extended;
  i, np, k,p: integer;
  buffer, Result, Px, Pz: string;
  flag, prenos: boolean;
label LabelSave1, LabelSave2;
begin
  if (Edit2.Text = '') then
      ShowMessage('Не сте въвели число за конвертиране!')
  else if (RadioButton2.Checked) then begin
      flag := false;
      cqlaChast := trunc(StrToFloat(Edit2.Text));
      bufCqlaChast := cqlaChast;
      if (cqlaChast = 0) then flag := true;
      buffer := '';
      Result := '';
      if (StrToFloat(Edit2.Text) = 0.0) then Result := '0';
      while (cqlaChast <> 1) and (cqlaChast <> 0) do begin
        if (cqlaChast mod 2 <> 0) then begin
          cqlaChast := cqlaChast div 2;
          Result := Result + '1';
        end
        else begin
          cqlaChast := cqlachast div 2;
          Result := Result + '0';
        end;
      end;
      if (cqlaChast = 1) then
        Result := Result + '1';
      for i := 1 to Length(Result) do
        buffer := Result[i] + buffer;
      Result := buffer;
      
      if (Pos(',', Edit2.Text) > 0) then begin
        drobnaChast := StrToFloat(Edit2.Text) - bufCqlaChast;
        if (drobnaChast = 0) then goto LabelSave1;
        np := round((Length(FloatToStr(drobnaChast)) - 2) / 0.30103);
        if (flag) then Result := Result + '0,'
        else Result := Result + ',';
        while(np <> 0) do begin
          drobnaChast := drobnaChast * 2;
          if (drobnaChast >= 1) then begin
            drobnaChast := drobnaChast - 1;
            Result := Result + '1';
            if (drobnaChast = 0) then break;
          end
          else
            Result := Result + '0';
          np := np - 1;
        end;
        if (drobnaChast = 1) then
          Result := Result + '1';
      end;
      LabelSave1:
      Memo2.Text := Result;
      Result := '(' + Edit2.Text + ')10  -  (' + Result + ')2';
  end
  else if (RadioButton1.Checked) then begin
    if (Pos(',', Edit2.Text) > 0) then begin
      Result := '';
      for i := 1 to Pos(',', Edit2.Text)-1 do begin
        Result := Result + Edit2.Text[i];
      end;
      for i := Pos(',', Edit2.Text)+1 to Length(Edit2.Text) do begin
        Px := Px + Edit2.Text[i];
      end;
    Result := IntToStr(BinToInt(Result));
    if (StrToInt(Px) = 0) then goto LabelSave2;
    Pz := '';
    k := Length(Px);
    while (k mod 4 > 0) do
      k := k+1;
    for i:=1 to k do begin
      Pz := Pz + '0';
    end;

    for i := Length(Px) downto 1 do begin
      for p:=Length(Pz) downto 1 do
        Pz[p] := Pz[p-1];
      Pz[1] := Px[i];
      k := 1;
      while k < Length(Pz)-2 do begin
      if (Pz[k] = '1') then begin
        if (Pz[k+3] = '1') then begin
          prenos := true;
          Pz[k+3] := '0';
        end
        else begin
          Pz[k+3] := '1';
          prenos := false;
        end;

        if (Pz[k+2] = '1') then begin
          if (prenos) then begin
            Pz[k+2] := '0';
            prenos := true;
          end
          else begin
            Pz[k+2] := '1';
            prenos := false;
          end;
        end
        else begin
          if (prenos) then
            Pz[k+2] := '1'
          else Pz[k+2] := '0';
          prenos := false;
        end;

        if (Pz[k+1] = '1') then begin
          if (prenos) then
            Pz[k+1] := '1'
          else
            Pz[k+1] := '0';
          prenos := true;
        end
        else begin
          if (prenos) then begin
            Pz[k+1] := '0';
            prenos := true;
          end
          else begin
            Pz[k+1] := '1';
            prenos := false;
          end;
        end;

        if (Pz[k] = '0') then begin
          if (prenos) then
            Pz[k] := '0'
          else Pz[k] := '1';
        end
        else begin
          if (prenos) then
            Pz[k] := '1'
          else Pz[k] := '0';
        end;
      end; //end if (Pz[k] = '1')
      k := k + 4;
      end;
    end; //end for()

    buffer := '';
    Px := '';
    for i:=1 to Length(Pz) do begin
      buffer := buffer + Pz[i];
      if (i mod 4 = 0) then begin
         Px := Px + IntToStr(BinToInt(buffer));
         buffer := '';
      end;
    end;
    LabelSave2:
    Memo2.Text := Result + ',' + Px;
    Result := '(' + Edit2.Text + ')2  -  (' + Result + ',' + Px + ')10';   
    end
    else begin
      Result := Edit2.Text;
      Result := IntToStr(BinToInt(Result));
      Memo2.Text := Result;
      Result := '(' + Edit2.Text + ')2  -  (' + Result + ')10';
    end;
  end;
  {$I-} Append(resultFile); {$I+}
  if ioresult <> 0 then begin
    ShowMessage('Грешка при отваряне на файла!');
    exit;
  end
  else writeln(resultFile, Result);
  CloseFile(resultFile);
end;

procedure TForm1.Edit2KeyPress(Sender: TObject; var Key: Char);
begin
  if (RadioButton2.Checked) then begin
    if (Key in ['0'..'9', ',', #8] = false) or ((Pos(',', Edit2.Text) > 0) and (Key = ',')) then
      Key := #10
  end
  else if (RadioButton1.Checked) then
    if (Key in ['0', '1', ',', #8] = false) or ((Pos(',', Edit2.Text) > 0) and (Key = ',')) then
      Key := #10;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  AssignFile(resultFile, 'Result.txt');
  Rewrite(resultFile);
  CloseFile(resultFile);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Edit2.Text := '';
  Memo2.Text := '';
end;

procedure TForm1.Exit1Click(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.About2Click(Sender: TObject);
begin
  Form2.Show;
end;

function BinToInt(Value: String): Int64;
var i: Integer;
begin
  Result := 0;
  while Copy(Value, 1, 1) = '0' do
    Value := Copy(Value, 2, Length(Value) - 1) ;
  for i := Length(Value) downto 1 do
    if Copy(Value, i, 1) = '1' then
      Result := Result + (1 shl (Length(Value) - i)) ;
end;

procedure TForm1.Cut1Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.CutToClipboard
  else if (Memo2.Focused) then
    Memo2.CutToClipboard;
end;

procedure TForm1.Paste1Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.PasteFromClipboard
  else if (Memo2.Focused) then
    Memo2.PasteFromClipboard;
end;

procedure TForm1.Copy1Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.CopyToClipboard
  else if (Memo2.Focused) then
    Memo2.CopyToClipboard;
end;

procedure TForm1.Clear1Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.ClearSelection
  else if (Memo2.Focused) then
    Memo2.ClearSelection;
end;

procedure TForm1.Cut2Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.CutToClipboard
  else if (Memo2.Focused) then
    Memo2.CutToClipboard;
end;

procedure TForm1.Copy2Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.CopyToClipboard
  else if (Memo2.Focused) then
    Memo2.CopyToClipboard;
end;

procedure TForm1.Paste2Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.PasteFromClipboard
  else if (Memo2.Focused) then
    Memo2.PasteFromClipboard;
end;

procedure TForm1.Clear2Click(Sender: TObject);
begin
  if (Edit2.Focused) then
    Edit2.ClearSelection
  else if (Memo2.Focused) then
    Memo2.ClearSelection;
end;

procedure TForm1.Memo2KeyPress(Sender: TObject; var Key: Char);
begin
  Key := #0;
end;

end.
