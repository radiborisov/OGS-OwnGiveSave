import React, {useState} from 'react';
import { StyleSheet, Text, View, Button} from 'react-native';

export default function App() {
  const [outputText, setOutputText] = useState("Welcome to our app!")
  return (
    <View style={styles.container}>
      <Text>{outputText}</Text>
      <Button title = "Welcome to our app!" onPress={() => setOutputText('Its not finished yet.')}/>  
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
