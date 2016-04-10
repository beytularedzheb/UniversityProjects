package dpteacher.decorator;

import dpteacher.IOperations;
import dpteacher.Teacher;
import dpteacher.TeacherAdapter;
import java.util.List;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class DataValidationProxy implements IOperations {
    private TeacherAdapter target;

    public DataValidationProxy(TeacherAdapter teacherAdapter) {
        this.target = teacherAdapter;
    }
    
    private boolean validate(Teacher teacher) {
        return !(teacher.getTitle().isEmpty() || 
                teacher.getFirstName().isEmpty() || 
                teacher.getLastName().isEmpty() ||
                (teacher.getPid() != null && teacher.getPid().isEmpty()));
    }
    
    @Override
    public void write(Teacher teacher) {
        if (validate(teacher)) {
            this.target.write(teacher);
            JOptionPane.showMessageDialog(new JFrame(),
                "Saved!");
        }
        else {
            JOptionPane.showMessageDialog(new JFrame(),
                "Please fill out all fields!",
                "",
                JOptionPane.WARNING_MESSAGE);
        }
    }

    @Override
    public List<Teacher> readAll() {
        return this.target.readAll();
    }

    @Override
    public Teacher read(int id) {
        return this.target.read(id);
    }
    
}
