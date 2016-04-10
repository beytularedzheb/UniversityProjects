function [result] = getMinLabel(label, linkedWith)
       minElem = min(linkedWith{label});
       prev = label;
       while(minElem ~= prev)
           prev = minElem;
           minElem = min(linkedWith{minElem});
       end;
       
       result = minElem;