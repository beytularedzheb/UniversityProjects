package dpteacher;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class TeacherSortByNameProxy implements IOperations {    
    private TeacherAdapter target;
    
    public TeacherSortByNameProxy(TeacherAdapter target) {
        this.target = target;
    }
    
    @Override
    public void write(Teacher teacher) {
        this.target.write(teacher);
    }

    @Override
    public List<Teacher> readAll() {
        List result = this.target.readAll();
        Collections.sort(result, new Comparator<Teacher>() {
            public int compare(Teacher t1, Teacher t2) {
                return t1.getFirstName().compareTo(t2.getFirstName());
            }
        });
        
        return result;
    }

    @Override
    public Teacher read(int id) {
        return this.target.read(id);
    }
}
