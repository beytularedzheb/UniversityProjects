package dpteacher;

import java.util.List;

public interface IOperations {

    public void write(Teacher teacher);

    public List<Teacher> readAll();

    public Teacher read(int id);
}
