using System;
// este delegate e' a base para o event Move do slider
public delegate void MoveEventHandler(object source, MoveEventArgs e);


// esta  classe contem os argumentos do evento move do slider
public class MoveEventArgs : EventArgs
{
    private int x ;
    public MoveEventArgs (int x)
    {
            this.x = x;
    }
    
    public int X
    {
        get
        {
            return x;
        }
    }
}


class Slider
{

    public event MoveEventHandler Moved;
    private int position;

    public void OnMoved( MoveEventArgs e)
    {
        if (Moved != null) 
            Moved(this, e);
    }

    public void Validate( int a)
    {
        if (a <= 50)
        {
            position = a;
        }
        else
        {
            // callback tal que, se a nova posição for maior que 50, então é inválida
            Moved += new MoveEventHandler(this.Callback);
        }
    }

    public int Position
    {
        get
        {
            return position;
        }
        // e' este bloco que e' executado quando se move o slider
        set
        {
            Validate(value);
            OnMoved(new MoveEventArgs(value));
            
        }
    }

    public void Callback (object source , MoveEventArgs e)
    {
            
            Console.WriteLine("Slider position {0} is invalid", e.X);          
    }

}


class Form
{
    

    static void Main()
    {
        Slider slider = new Slider();
        
        
        // TODO: register with the Move event

        slider_Move(slider, new MoveEventArgs(60));

        // estas sao as duas alteracoes simuladas no slider
        // slider.Position = 20;
        // slider.Position = 60;
        Console.WriteLine("Slider position:{0}", slider.Position);
        Console.ReadKey();
        
    }

    // este é o método que deve ser chamado quando o slider e' movido
    static void slider_Move(object source, MoveEventArgs e)
    {
        Slider slider = (Slider)source;
        slider.Position = e.X;
    }
}
