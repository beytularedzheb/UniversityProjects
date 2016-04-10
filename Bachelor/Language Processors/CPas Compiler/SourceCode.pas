unit SourceCode;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, StdCtrls, ComCtrls, ExtCtrls, Grids, RichEdit, ShellAPI,
  Buttons, ToolWin, ImgList, ActnMan, ActnCtrls, ActnMenus, Gauges, ActnList,
  SyntacticAnalysis, SemanticAnalysis, GenerateObjectCode;

type
  TformMain = class(TForm)
    mainMenu: TMainMenu;
    File1: TMenuItem;
    Edit1: TMenuItem;
    Help1: TMenuItem;
    New1: TMenuItem;
    Open1: TMenuItem;
    Save1: TMenuItem;
    SaveAs1: TMenuItem;
    N1: TMenuItem;
    Exit1: TMenuItem;
    Copy1: TMenuItem;
    Cut1: TMenuItem;
    Paste1: TMenuItem;
    N2: TMenuItem;
    Delete1: TMenuItem;
    About1: TMenuItem;
    Execute1: TMenuItem;
    Compile1: TMenuItem;
    warningPanel: TRichEdit;
    dlgOpen: TOpenDialog;
    dlgSave: TSaveDialog;
    lineNumber: TRichEdit;
    Highlight1: TMenuItem;
    N3: TMenuItem;
    sourceEdit: TRichEdit;
    dlgColor: TColorDialog;
    ToolBar: TToolBar;
    popupMenu: TPopupMenu;
    Cut2: TMenuItem;
    Copy2: TMenuItem;
    Paste2: TMenuItem;
    N4: TMenuItem;
    Delete2: TMenuItem;
    imageListToolBar: TImageList;
    btnNew: TToolButton;
    btnOpen: TToolButton;
    btnSave: TToolButton;
    btnSep1: TToolButton;
    btnCut: TToolButton;
    btnCopy: TToolButton;
    btnPaste: TToolButton;
    btnSep2: TToolButton;
    btnTools: TToolButton;
    btnLock: TToolButton;
    btnRun: TToolButton;
    btnSep3: TToolButton;
    imageListMainMenu: TImageList;
    pageCtrl: TPageControl;
    tabErrorPage: TTabSheet;
    sgCodeList: TStringGrid;
    tblTetrads: TStringGrid;
    SplitterOfPages: TSplitter;
    SplitterOfTetrTable: TSplitter;
    btnDebug: TSpeedButton;
    btnSep4: TToolButton;
    btnSep5: TToolButton;
    btnGenASM: TSpeedButton;
    dlgFont: TFontDialog;
    Font1: TMenuItem;
    procedure FormCreate(Sender: TObject);
    procedure Open1Click(Sender: TObject);
    procedure Compile1Click(Sender: TObject);
    procedure Save1Click(Sender: TObject);
    procedure SaveAs1Click(Sender: TObject);
    procedure Copy1Click(Sender: TObject);
    procedure Cut1Click(Sender: TObject);
    procedure Paste1Click(Sender: TObject);
    procedure Delete1Click(Sender: TObject);
    procedure New1Click(Sender: TObject);
    procedure btnOpenClick(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
    procedure btnCutClick(Sender: TObject);
    procedure btnCopyClick(Sender: TObject);
    procedure btnPasteClick(Sender: TObject);
    procedure btnRunClick(Sender: TObject);
    procedure Exit1Click(Sender: TObject);
    procedure btnLockClick(Sender: TObject);
    procedure Highlight1Click(Sender: TObject);
    procedure btnNewClick(Sender: TObject);
    procedure Cut2Click(Sender: TObject);
    procedure Copy2Click(Sender: TObject);
    procedure Paste2Click(Sender: TObject);
    procedure Delete2Click(Sender: TObject);
    procedure btnDebugClick(Sender: TObject);
    procedure btnGenASMClick(Sender: TObject);
    procedure Font1Click(Sender: TObject);
    procedure About1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    highlightcolor: TColor;
    HighLightList: TStringlist;
    OldRichEditWndProc: {integer} pointer;
    PRichEditWndProc: pointer;
  end;

var
  formMain: TformMain;

  fname: string = '';
  LN: set of char = ['A'..'Z', 'a'..'z', 'А'..'п', 'р'..'я', #95];
  srcFile: TextFile;
  ReservedWordsArr: array[1..100] of string;
  isSuc: boolean;

  procedure PrintTetrads;
  procedure PrintPointListArr;
  procedure LexAnal;
  function HighLight: boolean;
  
implementation

uses SourceCodeAbout;

{$R *.dfm}

procedure PrintTetrads;
var
  i: integer;
begin
  with formMain do begin
    tblTetrads.RowCount := TetN;

    for i := 1 to TetN-1 do begin
      tblTetrads.Cells[1, i] := Tetr[i].KO;
      if (Tetr[i].Op1 <> -1) then begin
        if (Tetr[i].flag) then
          tblTetrads.Cells[2, i] := SymbolsArr[Tetr[i].Op1].Symb
        else
          tblTetrads.Cells[2, i] := '#' + IntToStr(Tetr[i].Op1);
      end;
      tblTetrads.Cells[3, i] := SymbolsArr[Tetr[i].Op2].Symb;
      tblTetrads.Cells[4, i] := SymbolsArr[Tetr[i].Result].Symb;
      tblTetrads.Cells[5, i] := Tetr[i].Etiket;
      tblTetrads.Cells[0, i] := IntToStr(i);
    end;
  end
end;

procedure PrintPointListArr;
var
  i, j: integer;
begin
  with formMain.sgCodeList do begin
    for j := 0 to indexList-1 do begin
      i := PointListArr[j];
      Cells[0, j+1] := SymbolsArr[i].Symb;
      Cells[1, j+1] := IntToStr(SymbolsArr[i].Code);
      if (SymbolsArr[i].Code = 222) or (SymbolsArr[i].Code = 111) then
        Cells[2, j+1] := FloatToStr(SymbolsArr[i].Value);
      RowCount := RowCount + 1;
    end;
    RowCount := indexList + 1;
  end;
end;

function HighLight:boolean;
var
  UText, WordName: string;
  FoundAt, WordLength: integer;
  i, Line: integer;
  hdc: integer;
  CharPosion: integer;
  FirstVisibleLine, LastVisibleLine: integer;
  FirstCharPosofLine: integer;
  h: hwnd;
  visrect: Trect;
  vispoint: TPoint;
  index: integer;
begin
  {Get the handle of the device context}
  h := formMain.sourceEdit.Handle;
  hdc := getdc(h);
  result := SendMessage (h, EM_GETRECT, 0, integer(@visrect)) = 0;
  if (result) then begin
    VisPoint.x       := VisRect.right;
    VisPoint.y       := VisRect.bottom;
    CharPosion       := SendMessage (h, EM_CHARFROMPOS, 0, integer(@VisPoint));
    LASTVISIBLELINE  := SendMessage (h, EM_LINEFROMCHAR, CharPosion, 0);
    FIRSTVISIBLELINE := SendMessage (h, EM_GETFIRSTVISIBLELINE, 0, 0);

    SetBkMode (hDC, TRANSPARENT);
    SelectObject(hdc, formMain.sourceEdit.font.Handle);


    for Line := FIRSTVISIBLELINE to LASTVISIBLELINE  do begin
      UText := ' ' + formMain.sourceEdit.Lines[Line];
      FirstCharPosofLine := SendMessage(formMain.sourceEdit.Handle, EM_LINEINDEX, Line, 0);
      i := 0;

      while (i <= LENgth(UText)) do begin
        FoundAt := i - 1;
        {Any character except these will count as a word delimiter}
        while (utext[i] in ['#','$','A'..'Z','a'..'z','0'..'9','{', '}','|',#60..#62,#42,#43,'!']) do  
          Inc(i);
        WordLength := i - FoundAt - 1;
        WordName := copy(UText, i - WordLength, WordLength);
        if (formMain.HighLightList.find(uppercase(WordName), index)) then begin
          SendMessage (formMain.sourceEdit.Handle, EM_POSFROMCHAR, integer(@VisPoint), FirstCharPosofLine + FoundAt-1);
          SetTextColor(hdc, formMain.highlightcolor);
          TextOut(hdc,  VisPoint.x,  VisPoint.y,  pchar(WordName), WordLength);
        end;
        Inc(i);
      end;
    end;
  end;
  ReleaseDC(formMain.sourceEdit.Handle, hDC);
end;

Function RichEditWndProc(handla: HWnd; uMsg, wParam, lParam: longint): longint stdcall;
begin
      Result := CallWindowProc(formMain.OldRichEditWndProc, handla, uMsg, wParam, lParam);
      if (uMsg = WM_PAINT) then
        HighLight;
End;

procedure TformMain.FormCreate(Sender: TObject);
var
  ch: char;
  buffer, codeInt: string;
  numbLine, i: integer;
begin
  pageCtrl.ActivePage := tabErrorPage;

  HighLightlist := tStringlist.Create;
  highlightcolor := RGB(255, 0, 95);

  PRichEditWndProc := @RichEditWndProc;
  formMain.sourceEdit.Perform(EM_EXLIMITTEXT, 0, 65535*32);
  formMain.sourceEdit.Enabled := false;
  formMain.sourceEdit.Color := cl3DLight;
  OldRichEditWndProc := Pointer(SetWindowLong(sourceEdit.Handle, GWL_WNDPROC, longint(@RichEditWndProc)));

  fname := '';
  sgCodeList.Cells[0, 0] := 'SYMBOL';
  sgCodeList.Cells[1, 0] := 'CODE';
  sgCodeList.Cells[2, 0] := 'VALUE';

  tblTetrads.Cells[0, 0] := '№';
  tblTetrads.Cells[1, 0] := 'Command';
  tblTetrads.Cells[2, 0] := 'Op1';
  tblTetrads.Cells[3, 0] := 'Op2';
  tblTetrads.Cells[4, 0] := 'Result';
  tblTetrads.Cells[5, 0] := 'Label';
    
  for numbLine := 1 to 70 do
    lineNumber.Lines.Text := lineNumber.Lines.Text + IntToStr(numbLine);

  codeInt := '';
  indexList := 0;
  AssignFile(srcFile, 'reserved.rcpas');
  {$I-} Reset(srcFile); {$I+}
  if (ioresult <> 0) then begin
    ShowMessage('Грешка при отваряне на файла с ключовите думи!');
    exit;
  end
  else begin
    buffer := '';
    Read(srcFile, ch);
    while not eof (srcFile) do begin
      if (ch in [#0..#32] = true) then begin
        Read(srcFile, ch);
      end
      else if not(ch in ['0'..'9']) then begin
        buffer := '';
        while not(ch in ['0'..'9', #0..#32]) do begin
          buffer := buffer + ch;
          Read(srcFile, ch);
        end;
      end
      else if (ch in ['0'..'9'] = true) then begin
        codeInt := '';
        while (ch in ['0'..'9'] = true) do begin
          codeInt := codeInt + ch;
          Read(srcFile, ch);
        end;
        HighLightList.Text := HighLightList.Text + buffer;

        with HighLightList do
          for i := 0 to count-1 do
            strings[i] := trim(strings[i]);
        HighLightList.sort;
        FindTab(buffer, StrToInt(codeInt), 0);
      end
      else warningPanel.Text := 'Лексична грешка: ' +
                                ch + ' - [Виж Файла с ключовите думи]';
    end;
    CloseFile(srcFile);
  end;
end;

procedure TformMain.Open1Click(Sender: TObject);
var
  buffer: string;
begin
  if (dlgOpen.Execute) then begin
    fname := dlgOpen.FileName;
    formMain.Caption := fname;
    AssignFile(srcFile, fname);
    
    { Зареждане съдържанието на файла в редактора }
    {$I-} Reset(srcFile); {$I+}
    if ioresult <> 0 then begin
      ShowMessage('Грешка при отваряне сорс файла!');
      exit;
    end
    else begin
      sourceEdit.Enabled := true;
      sourceEdit.Color := RGB(28, 28, 28);
      buffer := '';
      sourceEdit.Text := '';
      while not eof (srcFile) do begin
        Readln(srcFile, buffer);
        sourceEdit.Lines.Text := sourceEdit.Lines.Text + buffer; 
      end;
    end;
    CloseFile(srcFile);
  end;
end;

procedure LexAnal;
var
  indChar, P, symbCode: integer;
  ch: char;
  strBuffer: string;
  flagDot: boolean;
begin
  indChar := 0;
  if (formMain.sourceEdit.Text <> '') then begin
    while indChar <= Length(formMain.sourceEdit.Text) do begin
      Inc(indChar);
      ch := formMain.sourceEdit.Text[indChar];
      if (ch in [#0..#32]) then
        continue
      else if (ch in LN) then begin
        strBuffer := '';
        while ((ch in LN) or (ch in ['0'..'9', '_'])) do begin
          strBuffer := strBuffer + ch;
          Inc(indChar);
          ch := formMain.sourceEdit.Text[indChar];
        end;
        Dec(indChar);
        symbCode := 111;
        P := FindTab(strBuffer, symbCode, 0);
        AddToList(P);
      end
      else if (ch in ['0'..'9']) then begin
        flagDot := false;
        strBuffer := '';
        Inc(indChar);
        if (formMain.sourceEdit.Text[indChar] in LN = true) then begin
          formMain.warningPanel.Text := 'Имената на променливите не могат ' +
                                        'да започват с число.';
          isSuc := false;
          exit;
        end;
        Dec(indChar);
        while (ch in ['0'..'9', ',']) do begin
          strBuffer := strBuffer + ch;
          if (ch = '.') and (flagDot = true) then begin
            formMain.warningPanel.Text := 'Лексична грешка: " ' +
                                          strBuffer + ' "';
            isSuc := false;
            exit;
          end;
          if (ch = ',') then
            flagDot := true;
          Inc(indChar);
          ch := formMain.sourceEdit.Text[indChar];
        end;
        Dec(indChar);
        symbCode := 222;
        P := FindTab(strBuffer, symbCode, StrToFloat(strBuffer));
        AddToList(P);
      end
      else if (ch in [#33, #34, #36, #40..#47, #59..#62, #91, #93..#95, #123..#126]) then begin
        strBuffer := ch;
        if (ch in ['=', '!', '|', '$']) then begin
          Inc(indChar);
          ch := formMain.sourceEdit.Text[indChar];
          if (strBuffer = '=') then begin
            if (ch in ['=', '<', '>']) then
              strBuffer := strBuffer + ch
            else Dec(indChar);
          end
          else if (strBuffer = '!') then begin
            if (ch = '=') then
              strBuffer := strBuffer + ch
            else Dec(indChar);
          end
          else if (strBuffer = '|') then begin
            if (ch = '|') then
              strBuffer := strBuffer + ch
            else Dec(indChar);
          end
          else if (strBuffer = '$') then begin
            if (ch = '$') then
              strBuffer := strBuffer + ch
            else Dec(indChar);
          end
        end;
        P := FindTab(strBuffer, 0, 0);
        AddToList(P);
      end
      else begin
        formMain.warningPanel.Text := 'Лексична грешка: " ' + ch +' "';
        isSuc := false;
      end;
    end;
  end;
end;

procedure TformMain.Compile1Click(Sender: TObject);
var
  firstElem: integer;
begin
  if (sourceEdit.Text <> '') then
    Save1Click(Sender);
  warningPanel.Text := '';
  if (fname <> '') then begin
    isSuc := true;
    firstElem := 0;
    indexList := 0;
    LexAnal();
    if (isSuc) then begin
      if (sourceEdit.Text <> '') then begin
        if (SymbolsArr[PointListArr[firstElem]].Code = 33) then begin
          warningPanel.Text := SyntAnal(SymbolsArr, PointListArr, indexList);
          if (warningPanel.Text = '') then begin
            SemAnal(SymbolsArr, PointListArr, indexList);
            NovaTetrada('STOP', -1, -1, -1, true);
            step := 1;
            PrintPointListArr;
            PrintTetrads;
            tblTetrads.Row := 1;
            btnGenASM.Enabled := true;
            btnDebug.Enabled := true;
          end;
        end
        else warningPanel.Text := 'Очаква се "void", но е намерен: ' +
                                  SymbolsArr[PointListArr[firstElem]].Symb;
        pageCtrl.ActivePage := tabErrorPage;
      end
      else begin
        warningPanel.Text := '';
      end;
    end;
  end;
end;

procedure TformMain.Save1Click(Sender: TObject);
begin
  if (fname = '') then begin
    SaveAs1Click(Sender);
  end
  else begin
    Rewrite(srcFile);
    write(srcFile, sourceEdit.Text);
    CloseFile(srcFile);
  end;
end;

procedure TformMain.SaveAs1Click(Sender: TObject);
begin
  if (dlgSave.Execute) then begin
    fname := dlgSave.FileName;
    if (Pos('.cpas', fname) = 0) then
      fname := fname + '.cpas';
    formMain.Caption := fname;
    AssignFile(srcFile, fname);
    Rewrite(srcFile);
    write(srcFile, sourceEdit.Text);
    CloseFile(srcFile);
  end;
end;

procedure TformMain.Copy1Click(Sender: TObject);
begin
  if (sourceEdit.Focused) then
    sourceEdit.CopyToClipboard
  else if (warningPanel.Focused) then
    warningPanel.CopyToClipboard;
end;

procedure TformMain.Cut1Click(Sender: TObject);
begin
  sourceEdit.CutToClipboard;
end;

procedure TformMain.Paste1Click(Sender: TObject);
begin
  sourceEdit.PasteFromClipboard;
end;

procedure TformMain.Delete1Click(Sender: TObject);
begin
  sourceEdit.ClearSelection;
end;

procedure TformMain.New1Click(Sender: TObject);
begin
  fname := '';
  sourceEdit.Text := '';
  warningPanel.Text := '';
  sgCodeList.RowCount := 2;
  sgCodeList.Cells[0, 1] := '';
  sgCodeList.Cells[1, 1] := '';
  sourceEdit.Enabled := true;
  sourceEdit.Color := RGB(28, 28, 28);
end;

procedure TformMain.btnOpenClick(Sender: TObject);
begin
  Open1Click(Sender);
end;

procedure TformMain.btnSaveClick(Sender: TObject);
begin
  Save1Click(Sender);
end;

procedure TformMain.btnCutClick(Sender: TObject);
begin
  Cut1Click(Sender);
end;

procedure TformMain.btnCopyClick(Sender: TObject);
begin
  Copy1Click(Sender);
end;

procedure TformMain.btnPasteClick(Sender: TObject);
begin
  Paste1Click(Sender);
end;

procedure TformMain.btnRunClick(Sender: TObject);
begin
  Compile1Click(Sender);
  Beep;
end;

procedure TformMain.Exit1Click(Sender: TObject);
begin
  formMain.Close;
end;

procedure TformMain.btnLockClick(Sender: TObject);
begin
  if (sourceEdit.ReadOnly) then begin
    sourceEdit.ReadOnly := false;
    btnLock.ImageIndex := 9;
    btnLock.Hint := 'Lock...';
  end
  else begin
    sourceEdit.ReadOnly := true;
    btnLock.ImageIndex := 8;
    btnLock.Hint := 'Unlock...';
  end;
end;

procedure TformMain.Highlight1Click(Sender: TObject);
begin
  if (dlgColor.Execute = true) then
    highlightcolor := dlgColor.Color;
  sourceEdit.Invalidate;
end;


procedure TformMain.btnNewClick(Sender: TObject);
begin
  New1Click(Sender);
end;

procedure TformMain.Cut2Click(Sender: TObject);
begin
  Cut1Click(Sender);
end;

procedure TformMain.Copy2Click(Sender: TObject);
begin
  Copy1Click(Sender);
end;

procedure TformMain.Paste2Click(Sender: TObject);
begin
  Paste1Click(Sender);
end;

procedure TformMain.Delete2Click(Sender: TObject);
begin
  Delete1Click(Sender);
end;

procedure TformMain.btnDebugClick(Sender: TObject);
begin
  if (step < tetN-1) then begin
    tblTetrads.Row := GenObjCode;
    PrintPointListArr;
  end
  else begin
    Compile1Click(Sender);    
    ShowMessage('Край на изпълнението!');
  end;
end;

procedure TformMain.btnGenASMClick(Sender: TObject);
begin
  GenASMCode;
  isCreatedASM := false;
  ShowMessage('Асемблерският код е генериран!' + #10#13 +
              'Файлът се намира в директорията на програмата с име: ' +
              'GeneratedASM.asm');
end;

procedure TformMain.Font1Click(Sender: TObject);
begin
  if (dlgFont.Execute) then
    sourceEdit.Font := dlgFont.Font;
end;

procedure TformMain.About1Click(Sender: TObject);
begin
  formAbout.Show;
end;

end.

