public static class MysteryStack1 { 
    public static string Run(string text) {
        var stack = new Stack<char>(); //create a new stack (LIFO)
        foreach (var letter in text) //go for every letter in the text
            stack.Push(letter); //add to the back of the stack

        var result = ""; //create an empty chain to order the result
        while (stack.Count > 0) //if the stack still having elements it keeps running
            result += stack.Pop(); //pop the las element and show it in order of pop (carla ---> alrac)

        return result;
    }
}