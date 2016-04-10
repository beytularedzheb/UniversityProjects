function [dif] = freeman2dif(fcode)
    for i=1:size(fcode, 2)
        if (i == size(fcode, 2))
            dif(i) = mod(fcode(i) - fcode(1), 8);
        else
            dif(i) = mod(fcode(i) - fcode(i+1), 8);
        end;
    end;
    