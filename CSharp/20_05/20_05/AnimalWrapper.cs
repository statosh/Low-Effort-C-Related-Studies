public class AnimalWrapper {
    private IAnimal animal;

    public AnimalWrapper(IAnimal animal) {
        this.animal = animal;
    }

    public string GetName() {
        return animal.GetName();
    }

    public void MakeSound() {
        animal.MakeSound();
    }
}