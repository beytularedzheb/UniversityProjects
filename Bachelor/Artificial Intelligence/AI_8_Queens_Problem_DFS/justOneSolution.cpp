#include <vector>
#include <queue>
#include <iostream>
#include <cstdlib> // abs()

using namespace std;

struct Position {
	short row;
	short column;
};

struct NBoard {
	int N;
	int LIdx;
	vector<Position> Assign;

	NBoard(const NBoard & a) {
    	N = a.N;
    	LIdx = a.LIdx;
    	Assign.resize(N);
    	copy(a.Assign.begin(), a.Assign.end(), Assign.begin());
  	}

  	NBoard(int n) {
    	N = n;
    	LIdx = -1;
    	Assign.resize(N);
  	}

  	NBoard & operator = (const NBoard & other) {
		if (this != &other) {
			if (N != other.N)
         		Assign.resize(other.N);
      		copy(other.Assign.begin(), other.Assign.end(), Assign.begin());
      		N = other.N;
      		LIdx = other.LIdx;
    	}
    	return *this;
  	}

  	bool PlaceQueen(Position p) {
		for (int i = 0; i <= LIdx; i++) {
			if (p.column == Assign[i].column ||
				abs(p.row - Assign[i].row) == abs(p.column - Assign[i].column))
				return false;
    	}
    	LIdx++;
   		Assign[LIdx] = p;
    	return true;
  	}

  	void RemoveQueen() {
    	LIdx--;
  	}

  	int Level() {
    	return LIdx + 1;
  	}
};

void FindSolutionDFS(int n) {
	NBoard curBoard(n);
	queue<NBoard> boards;
	Position pos;

	for (int i = 0; i < n; i++){
  		pos.row = 0;
  		pos.column = i;
  		curBoard.PlaceQueen(pos);
  		boards.push(curBoard);
  		curBoard.RemoveQueen();
	}

	do {
  		curBoard = boards.front();
  		boards.pop();
  		pos.row = curBoard.Level();

  		for (int i = 0; i < n; i++) {
    		pos.column = i;
			if (curBoard.PlaceQueen(pos)) {
   				if (curBoard.Level() == n) {
   					/* Печатане на решението и прекратяване на търсенето на други */
     				for (vector<Position>::iterator it = curBoard.Assign.begin();
	 	  				 it != curBoard.Assign.end(); ++it) {
						cout << "(" << it->row << ", " << it->column << ") ";
	 	  			}

					return;
   				}
				else {
    				boards.push(curBoard);
   				}
   				curBoard.RemoveQueen();
        	}
  		}
	} while(true);
}
	
int main() {

  	int numOfQueens = 8;

  	FindSolutionDFS(numOfQueens);
  	
  	return 0;
}
