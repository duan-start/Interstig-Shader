#version 330 core

out vec4 FragColor;
in vec2 Pos;
in vec2 stand;
in vec2 screen;
uniform float iTime;

#define t iTime
#define r screen.xy

//һ�����к���
vec3 palette(float t){
vec3 a=vec3 (.5,.5,.5);
vec3 b=vec3 (.5,.5,.5);
vec3 c=vec3 (1.,1.,1.);
vec3 d=vec3 (0.263,.416,.557);
    return a+b*cos( 6.28318*(c*t+d));
    }

void main(){
vec2 uv =stand;
uv.x*=screen.x/screen.y;
//��ȡ��Ļ�������Ա仯
vec2 uv0=uv;
//�����ظ��͵�����
vec3 final=vec3(0.,0.,0.);

for(float i=0.;i<4.;i++){

  //�ض�
  uv=fract(uv*1.5)-0.5;
  float d=length(uv)*exp(-length(uv0));
  
  //������κ���ְ�
  vec3 col=palette(length(uv0)+i*.4+t*.4);
  //ʱ���������ѭ��
  d = sin(d*8.+t)/8.;
  d=abs(d);
  //step ��������֤С���������ֵȫ������Ϊ0
  //d=step(0.1,d);
  
  //smoothstep ��������ֵ֮���ƽ������
  // d=smoothstep(0.,0.1,d);
  //�����������У�����ֱ��ʹ��smooth
  d=pow(0.01/d,1.2);
  final+=col*d;
}


FragColor=vec4(final,0.);

}