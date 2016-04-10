unit VectorFileSC;

interface

type

  Element = record
    name: string[20];
    parameters: array[1..4] of integer;
    textMsg: string[100];
  end;

var

  elements: array[1..100] of Element;
  elementsCount, lastStateVal: byte;
  fileHandler: file of Element;

  procedure addElement(name: string; p1, p2, p3, p4: integer); overload;
  procedure addElement(name: string; p: integer); overload;
  procedure addElement(name, txtMSG: string; p1, p2: integer); overload;
  procedure saveVectorFile(filename: string; openedAndEdit: boolean);

implementation

procedure addElement(name: string; p1, p2, p3, p4: integer); overload;
begin
  Inc(elementsCount);
  lastStateVal := elementsCount;
  elements[elementsCount].name := name;
  elements[elementsCount].parameters[1] := p1;
  elements[elementsCount].parameters[2] := p2;
  elements[elementsCount].parameters[3] := p3;
  elements[elementsCount].parameters[4] := p4;
end;

procedure addElement(name: string; p: integer); overload;
begin
  Inc(elementsCount);
  lastStateVal := elementsCount;
  elements[elementsCount].name := name;
  elements[elementsCount].parameters[1] := p;
end;

procedure addElement(name, txtMSG: string; p1, p2: integer); overload;
begin
  Inc(elementsCount);
  lastStateVal := elementsCount;
  elements[elementsCount].name := name;
  elements[elementsCount].textMsg := txtMSG;
  elements[elementsCount].parameters[1] := p1;
  elements[elementsCount].parameters[2] := p2;
end;

procedure saveVectorFile(fileName: string; openedAndEdit: boolean);
var
  i: integer;
begin
  AssignFile(fileHandler, fileName);
  if (openedAndEdit) then begin
    Reset(fileHandler);
    Seek(fileHandler, FileSize(fileHandler));
    for i := 1 to elementsCount do
      Write(fileHandler, elements[i]);
  end
  else begin
    Rewrite(fileHandler);
    for i := 1 to elementsCount do
      Write(fileHandler, elements[i]);
  end;
  Close(fileHandler);
end;

end.

