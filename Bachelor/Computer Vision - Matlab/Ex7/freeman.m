function [fcode] = freeman(image, x, y)
directions = [ 1,  0;
               1, -1; 
               0, -1; 
              -1, -1; 
              -1,  0; 
              -1,  1;
               0,  1; 
               1,  1]; 
    currentX = x;
    currentY = y;
    pos = 1;
    imsize = size(image);
    fcode = [];
    
    while(true)
        nextX = currentX + directions(pos + 1, 1);
        nextY = currentY + directions(pos + 1, 2);
        if (nextY > 0 && nextY <= imsize(1) && nextX > 0 && nextX <= imsize(2) && image(nextY, nextX))
            fcode = [fcode, pos];
            currentX = nextX;
            currentY = nextY;
            pos = mod(pos + 2, 8);            
        else
            pos = mod(pos - 1, 8);
        end;         
        
        if (x == currentX && y == currentY && pos == 1)
            break;
        end;
    end;