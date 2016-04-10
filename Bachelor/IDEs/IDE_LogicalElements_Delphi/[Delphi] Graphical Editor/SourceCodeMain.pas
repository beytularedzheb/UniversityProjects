unit SourceCodeMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, ToolWin, ComCtrls, Buttons, ExtCtrls, StdCtrls, ImgList,
  ExtDlgs, Jpeg, VectorFileSC, ShellApi;

type
  TformMain = class(TForm)
    mainMenu: TMainMenu;
    mFile: TMenuItem;
    mNew: TMenuItem;
    mOpen: TMenuItem;
    mSave: TMenuItem;
    mSaveAs: TMenuItem;
    mHorLine1: TMenuItem;
    mExit: TMenuItem;
    Edit1: TMenuItem;
    mUndo: TMenuItem;
    mRedo: TMenuItem;
    mHelp: TMenuItem;
    mAbout: TMenuItem;
    formMainToolBar: TToolBar;
    btnNew: TSpeedButton;
    btnOpen: TSpeedButton;
    btnSave: TSpeedButton;
    btnUndo: TSpeedButton;
    btnRedo: TSpeedButton;
    btnSeparator: TToolButton;
    pnlElements: TPanel;
    pnlWithColors: TPanel;
    formMainStatusBar: TStatusBar;
    btnAND: TSpeedButton;
    btnNOR: TSpeedButton;
    btnVertLine: TSpeedButton;
    btnLine: TSpeedButton;
    pnlBackColor: TPanel;
    pnlForeColor: TPanel;
    penWidthTrackbar: TTrackBar;
    lblPenWitdth: TLabel;
    bvlColors: TBevel;
    bvlPenWidth: TBevel;
    cmbBrushStyle: TComboBox;
    imgLstBrush: TImageList;
    imgBrushStyle: TImage;
    pnlBrushStyle: TPanel;
    dlgFont: TFontDialog;
    dlgColor: TColorDialog;
    dlgSavePicture: TSavePictureDialog;
    dlgOpenPicture: TOpenPictureDialog;
    btnText: TButton;
    mFont: TMenuItem;
    mHorLine2: TMenuItem;
    drawBox: TScrollBox;
    drawImage: TImage;
    dlgOpenVector: TOpenDialog;
    procedure FormCreate(Sender: TObject);
    procedure pnlForeColorClick(Sender: TObject);
    procedure pnlBackColorClick(Sender: TObject);
    procedure penWidthTrackbarChange(Sender: TObject);
    procedure btnTextKeyPress(Sender: TObject; var Key: Char);
    procedure mNewClick(Sender: TObject);
    procedure btnNewClick(Sender: TObject);
    procedure mExitClick(Sender: TObject);
    procedure mSaveAsClick(Sender: TObject);
    procedure mSaveClick(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
    procedure mFontClick(Sender: TObject);
    procedure btnANDClick(Sender: TObject);
    procedure btnNORClick(Sender: TObject);
    procedure btnVertLineClick(Sender: TObject);
    procedure btnLineClick(Sender: TObject);
    procedure cmbBrushStyleChange(Sender: TObject);
    procedure cmbBrushStyleKeyPress(Sender: TObject; var Key: Char);
    procedure drawImageMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure drawImageMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure drawImageMouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure btnTextClick(Sender: TObject);
    procedure mUndoClick(Sender: TObject);
    procedure btnUndoClick(Sender: TObject);
    procedure btnRedoClick(Sender: TObject);
    procedure mRedoClick(Sender: TObject);
    procedure mAboutClick(Sender: TObject);
    procedure mOpenClick(Sender: TObject);
    procedure btnOpenClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
    cX, cY: integer;
    rX, rY: integer;
    choice: byte;
    textMsg: string;
    fileName: string;
    outStream: TFileStream;
    jpegImage: TJpegImage;

    procedure DrawAND(bX, bY, eX, eY: integer);
    procedure DrawNOR(bX, bY, eX, eY: integer);
    procedure DrawLine(bX, bY, eX, eY: integer);

    procedure TakeUndoPicture;
    procedure UndoPicture;
    procedure TakeRedoPicture;
    procedure RedoPicture;
  end;

  TPictureArray = array of TPicture;

  TLink = record
    x: integer;
    y: integer;
    r: real;
  end;

  TEllipseLink = array [1..100] of TLink;
  
var
  formMain: TformMain;

  eLink: TEllipseLink;
  linkCounter: integer = 0;
  
  aPicUndo: TPictureArray;
  aPicRedo: TPictureArray;
  openedAndEdit, saveOrNo: boolean;

implementation

uses SourceCodeAbout;

{$R *.dfm}

procedure TformMain.TakeUndoPicture;
var
  i: integer;
begin
  if Length(aPicUndo) = 4 then begin
    for i := 0 to 2 do begin
      aPicUndo[i].Assign(aPicUndo[i + 1]);
    end;
  end
  else begin
    Setlength(aPicUndo, Length(aPicUndo) + 1);
    aPicUndo[Length(aPicUndo) - 1] := TPicture.Create;
  end;
  
  aPicUndo[Length(aPicUndo) - 1].Assign(drawImage.Picture);
end;

procedure TformMain.UndoPicture;
begin
  if Length(aPicUndo) = 0 then
    exit;
    
  TakeRedoPicture;  
  drawImage.Picture.Assign(aPicUndo[Length(aPicUndo) - 1]);
  aPicUndo[Length(aPicUndo) - 1].Free;
  SetLength(aPicUndo, Length(aPicUndo) - 1);
  if (elementsCount > 0) then
    Dec(elementsCount);
end;

procedure TformMain.TakeRedoPicture;
var
  i: integer;
begin
  if Length(aPicRedo) = 4 then begin
    for i := 0 to 2 do begin
      aPicRedo[i].Assign(aPicRedo[i + 1]);
    end;
  end
  else begin
    Setlength(aPicRedo, Length(aPicRedo) + 1);
    aPicRedo[Length(aPicRedo) - 1] := TPicture.Create;
  end;
  
  aPicRedo[Length(aPicRedo) - 1].Assign(drawImage.Picture);
end;

procedure TformMain.RedoPicture;
begin
  if Length(aPicRedo) = 0 then
    exit;
    
  TakeUndoPicture;
  drawImage.Picture.Assign(aPicRedo[Length(aPicRedo) - 1]);
  aPicRedo[Length(aPicRedo) - 1].Free;
  SetLength(aPicRedo, Length(aPicRedo) - 1);
  if (elementsCount < lastStateVal) then
    Inc(elementsCount);
end;

procedure TformMain.DrawAND(bX, bY, eX, eY: integer);
var
  nColor: TColor;
  penW, fontSz: integer;
begin
  rX := eX - bX;
  rY := eY - bY;

  with drawImage.Canvas do begin
    fontSz := Font.Size;
    
    Rectangle(bX, bY, eX, eY);

    penW := Pen.Width;
    Pen.Width := 1;
    nColor := Pen.Color;
    Pen.Color := clRed;
    Ellipse(bX - 20, bY + Round(rY * 0.25) + 5, bX - 10, bY + Round(rY * 0.25) - 5);
    Pen.Color := nColor;
    Pen.Width := penW;

    MoveTo(bX - 10, bY + Round(rY * 0.25));
    LineTo(bX, bY + Round(rY * 0.25));

    penW := Pen.Width;
    Pen.Width := 1;
    nColor := Pen.Color;
    Pen.Color := clRed;
    Ellipse(bX - 20, bY + Round(rY * 0.75 ) + 5, bX - 10, bY + Round(rY * 0.75) - 5);
    Pen.Color := nColor;
    Pen.Width := penW;

    MoveTo(bX - 10, bY + Round(rY * 0.75));
    LineTo(bX, bY + Round(rY * 0.75));
    
    penW := Pen.Width;
    Pen.Width := 1;
    nColor := Pen.Color;
    Pen.Color := clRed;
    Ellipse(eX + 10, bY + Round(rY * 0.5) + 5, eX + 20, bY + Round(rY * 0.5) - 5);
    Pen.Color := nColor;
    Pen.Width := penW;

    MoveTo(eX, bY + Round(rY * 0.5));
    LineTo(eX + 10, bY + Round(rY * 0.5));

    Font.Size := Round(rY * 0.2);
    TextOut(eX - (Font.Size + Round(0.05 * rY)), bY + Round(0.03 * rY), '&');

    Font.Size := fontSz;
  end;
end;

procedure TformMain.DrawNOR(bX, bY, eX, eY: integer);
var
  nColor: TColor;
  penW, fontSz: integer;
begin
  rX := eX - bX;
  rY := eY - bY;

  with drawImage.Canvas do begin
    fontSz := Font.Size;

    Rectangle(bX, bY, eX, eY);

    penW := Pen.Width;
    Pen.Width := 1;
    nColor := Pen.Color;
    Pen.Color := clRed;
    Ellipse(bX - 20, bY + Round(rY * 0.5) + 5, bX - 10, bY + Round(rY * 0.5) - 5);
    Pen.Color := nColor;
    Pen.Width := penW;

    Ellipse(eX - 5, bY + Round(rY * 0.5) + 5, eX + 5, bY + Round(rY * 0.5) - 5);

    MoveTo(bX - 10, bY + Round(rY * 0.5));
    LineTo(bX, bY + Round(rY * 0.5));

    penW := Pen.Width;
    Pen.Width := 1;
    nColor := Pen.Color;
    Pen.Color := clRed;
    Ellipse(eX + 10, bY + Round(rY * 0.5) + 5, eX + 20, bY + Round(rY * 0.5) - 5);
    Pen.Color := nColor;
    Pen.Width := penW;

    MoveTo(eX + 5, bY + Round(ry * 0.5));
    LineTo(eX + 10, bY + Round(rY * 0.5));

    Font.Size := Round(rY * 0.2);
    TextOut(eX - Font.Size, bY + Round(0.03 * rY), '1');
    
    Font.Size := fontSz;
  end;
end;

procedure TformMain.DrawLine(bX, bY, eX, eY: integer);
begin
  with drawImage.Canvas do begin
    MoveTo(bX, bY);
    LineTo(eX, eY);
  end;
end;

procedure TformMain.FormCreate(Sender: TObject);
begin
  rX := 0;
  rY := 0;
  drawImage.Canvas.Pen.Color := clBlack;
  drawImage.Canvas.Brush.Color := clWhite;
  openedAndEdit := false;
  saveOrNo := false;
end;

procedure TformMain.pnlForeColorClick(Sender: TObject);
begin
  if (dlgColor.Execute) then begin
    pnlForeColor.Color := dlgColor.Color;
    drawImage.Canvas.Pen.Color := dlgColor.Color;

    addElement('ForeColor', dlgColor.Color);
    
    if (pnlForeColor.Color = clWhite) then
      pnlForeColor.Font.Color := clBlack
    else
      pnlForeColor.Font.Color := clWhite;
  end
end;

procedure TformMain.pnlBackColorClick(Sender: TObject);
begin
  if (dlgColor.Execute) then begin
    pnlBackColor.Color := dlgColor.Color;
    drawImage.Canvas.Brush.Color := dlgColor.Color;

    addElement('BackColor', dlgColor.Color);

    if (pnlBackColor.Color = clBlack) then
      pnlBackColor.Font.Color := clWhite
    else
      pnlBackColor.Font.Color := clBlack;
  end;
end;

procedure TformMain.penWidthTrackbarChange(Sender: TObject);
begin
  lblPenWitdth.Caption := 'Pen Width: ' + IntToStr(penWidthTrackbar.Position);
end;

procedure TformMain.btnTextKeyPress(Sender: TObject; var Key: Char);
begin
  if (choice = 5) then begin
    textMsg := textMsg + Key;
    saveOrNo := true;
    addElement('Text', textMsg, cX, cY);
    drawImage.Canvas.TextOut(cX, cY, textMsg);
  end;
end;

procedure TformMain.mNewClick(Sender: TObject);
begin
  fileName := '';
  drawImage.Picture := nil;
end;

procedure TformMain.btnNewClick(Sender: TObject);
begin
  mNewClick(Sender);
end;

procedure TformMain.mExitClick(Sender: TObject);
begin
  formMain.Close;
end;

procedure TformMain.mSaveAsClick(Sender: TObject);
begin
  if (dlgSavePicture.Execute) then begin
	  fileName := dlgSavePicture.FileName;
	  formMain.Caption := fileName;
	  drawImage.Picture.SaveToFile(fileName + '.bmp');
    jpegImage := TJpegImage.Create;
    jpegImage.Assign(drawImage.Picture.Bitmap);
    outStream := TFileStream.Create(fileName + '.jpg' ,fmOpenWrite or fmCreate);
    jpegImage.SaveToStream(outStream);
    outStream.Free;
    jpegImage.Free;
    saveVectorFile(fileName + '.vec', openedAndEdit);
    saveOrNo := false;
  end;
end;

procedure TformMain.mSaveClick(Sender: TObject);
begin
  if (fileName = '') then
    mSaveAsClick(Sender)
  else begin
    drawImage.Picture.SaveToFile(fileName + '.bmp');
    jpegImage := TJpegImage.Create;
    jpegImage.Assign(drawImage.Picture.Bitmap);
    outStream := TFileStream.Create(fileName + '.jpg' ,fmOpenWrite or fmCreate);
    jpegImage.SaveToStream(outStream);
    outStream.Free;
    jpegImage.Free;
    saveVectorFile(fileName + '.vec', openedAndEdit);
    saveOrNo := false;
  end;
end;

procedure TformMain.btnSaveClick(Sender: TObject);
begin
  mSaveClick(Sender);
end;

procedure TformMain.mFontClick(Sender: TObject);
begin
  if (dlgFont.Execute) then
    drawImage.Canvas.Font := dlgFont.Font;
end;

procedure TformMain.btnANDClick(Sender: TObject);
begin
  choice := 1;
end;

procedure TformMain.btnNORClick(Sender: TObject);
begin
  choice := 2;
end;

procedure TformMain.btnVertLineClick(Sender: TObject);
begin
  choice := 3;
end;

procedure TformMain.btnLineClick(Sender: TObject);
begin
  choice := 4;
end;

procedure TformMain.cmbBrushStyleChange(Sender: TObject);
begin
  if (cmbBrushStyle.Text = 'Solid') then begin
    drawImage.Canvas.Brush.Style := bsSolid;
    addElement('BrushStyle', 'Solid', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(0, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'BDiagonal') then begin
    drawImage.Canvas.Brush.Style := bsBDiagonal;
    addElement('BrushStyle', 'BDiagonal', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(6, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'FDiagonal') then begin
    drawImage.Canvas.Brush.Style := bsFDiagonal;
    addElement('BrushStyle', 'FDiagonal', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(1, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'Cross') then begin
    drawImage.Canvas.Brush.Style := bsCross;
    addElement('BrushStyle', 'Cross', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(2, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'DiagCross') then begin
    drawImage.Canvas.Brush.Style := bsDiagCross;
    addElement('BrushStyle', 'DiagCross', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(3, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'Horizontal') then begin
    drawImage.Canvas.Brush.Style := bsHorizontal;
    addElement('BrushStyle', 'Horizontal', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(4, imgBrushStyle.Picture.Bitmap);
  end
  else if (cmbBrushStyle.Text = 'Vertical') then begin
    drawImage.Canvas.Brush.Style := bsVertical;
    addElement('BrushStyle', 'Vertical', 0, 0);
    imgBrushStyle.Picture := nil;
    imgLstBrush.GetBitmap(5, imgBrushStyle.Picture.Bitmap);
  end;
end;

procedure TformMain.cmbBrushStyleKeyPress(Sender: TObject; var Key: Char);
begin
  Key := #0;
end;

procedure TformMain.drawImageMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
begin
  cX := X;
  cY := Y;
  formMainStatusBar.Panels[0].Text := IntToStr(X) + ' x ' + IntToStr(Y);
  
  if (drawImage.Canvas.Pen.Width <> penWidthTrackbar.Position) then begin
    addElement('PenWidth', penWidthTrackbar.Position);
    drawImage.Canvas.Pen.Width := penWidthTrackbar.Position;
  end;
end;

procedure TformMain.drawImageMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  TakeUndoPicture;
  formMainStatusBar.Panels[2].Text := IntToStr(X) + ' x ' + IntToStr(Y);

  if (choice = 1) then begin
    addElement('AND', cX, cY, X, Y);
    DrawAND(cX, cY, X, Y);
    saveOrNo := true;
  end
  else if (choice = 2) then begin
    addElement('NOR', cX, cY, X, Y);
    DrawNOR(cX, cY, X, Y);
    saveOrNo := true;
  end
  else if (choice = 3) then begin
    // Draw Vertical Line
    addElement('VLine', cX, cY, cX, Y);
    DrawLine(cX, cY, cX, Y);
    saveOrNo := true;
  end
  else if (choice = 4) then begin
    // Draw Normal Line
    addElement('NLine', cX, cY, X, Y);
    DrawLine(cX, cY, X, Y);
    saveOrNo := true;
  end
  else if (choice = 5) then begin
    textMsg := '';
  end;
end;

procedure TformMain.drawImageMouseMove(Sender: TObject; Shift: TShiftState;
  X, Y: Integer);
begin
  formMainStatusBar.Panels[1].Text := IntToStr(X) + ' x ' + IntToStr(Y);
end;

procedure TformMain.btnTextClick(Sender: TObject);
begin
  choice := 5;
end;

procedure TformMain.mUndoClick(Sender: TObject);
begin
  UndoPicture;
end;

procedure TformMain.btnUndoClick(Sender: TObject);
begin
  UndoPicture;
end;

procedure TformMain.btnRedoClick(Sender: TObject);
begin
  RedoPicture;
end;

procedure TformMain.mRedoClick(Sender: TObject);
begin
  RedoPicture;
end;

procedure TformMain.mAboutClick(Sender: TObject);
begin
  formAbout.Show;
end;

procedure TformMain.mOpenClick(Sender: TObject);
var
  elem: Element;
  X, Y: integer;
begin
  if (dlgOpenVector.Execute) then begin
    mNewClick(Sender);
    openedAndEdit := true;
    fileName := dlgOpenVector.FileName;
    formMain.Caption := fileName;
    AssignFile(fileHandler, fileName);
    Reset(fileHandler);
    while not eof(fileHandler) do begin
      Read(fileHandler, elem);

      cX := elem.parameters[1];
      cY := elem.parameters[2];
      X := elem.parameters[3];
      Y := elem.parameters[4];

      if (elem.name = 'PenWidth') then begin
        drawImage.Canvas.Pen.Width := cX;
        penWidthTrackbar.Position := cX;
      end
      else if (elem.name = 'AND') then begin
        DrawAND(cX, cY, X, Y);
      end
      else if (elem.name = 'NOR') then begin
        DrawNOR(cX, cY, X, Y);
      end
      else if (elem.name = 'NLine') then begin
         DrawLine(cX, cY, X, Y);
      end
      else if (elem.name = 'VLine') then begin
         DrawLine(cX, cY, X, Y);
      end
      else if (elem.name = 'ForeColor') then begin
        drawImage.Canvas.Pen.Color := cX;
        pnlForeColor.Color := cX;
      end
      else if (elem.name = 'BackColor') then begin
        drawImage.Canvas.Brush.Color := cX;
        pnlBackColor.Color := cX;
      end
      else if (elem.name = 'BrushStyle') then begin
        cmbBrushStyle.Text := elem.textMsg;
        cmbBrushStyleChange(Sender);
      end
      else if (elem.name = 'Text') then begin
        drawImage.Canvas.TextOut(cX, cY, elem.textMsg);
      end;
    end;
    CloseFile(fileHandler);
  end;
end;

procedure TformMain.btnOpenClick(Sender: TObject);
begin
  mOpenClick(Sender);
end;

procedure TformMain.FormClose(Sender: TObject; var Action: TCloseAction);
var
  result: integer;
begin
  if (saveOrNo) then
    result := MessageBox(0, PChar('Do you want to save the changes?'),
                  PChar('Confirm'),
                  MB_YESNO + MB_ICONQUESTION);
    if (result = mrYes) then
      mSaveClick(Sender);
end;

end.
