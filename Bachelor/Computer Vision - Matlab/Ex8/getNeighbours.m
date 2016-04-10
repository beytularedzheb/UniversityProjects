function [neigh] = getNeighbours(labels, x, y)

directions = [ 1,  0;
               0, -1; 
              -1,  0; 
               0,  1]; 
    neigh = [];
    
    for i=1:4
        nextX = x + directions(i, 1);
        nextY = y + directions(i, 2);
        if (labels(nextY, nextX) > 0)
            neigh = [neigh, labels(nextY, nextX)];
        end
    end;          