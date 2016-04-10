package dpteacher;

import java.util.List;

public class TeacherAdapter implements IOperations {

    private TeacherSingleton adaptee;
    
    public TeacherAdapter() {
        adaptee = TeacherSingleton.getInstance();
    }
    
    @Override
    public void write(Teacher teacher) {
        adaptee.addTeacher(teacher);
    }

    @Override
    public Teacher read(int id) {
        return adaptee.getTeacher(id);
    }

    @Override
    public List<Teacher> readAll() {
        return adaptee.getTeachers();
    }
}
